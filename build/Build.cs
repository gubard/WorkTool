extern alias NC;
using NC::Nuke.Common.Tools.DotNet;

using static NC::Nuke.Common.Tools.DotNet.DotNetTasks;

using GitVersion = NC::Nuke.Common.Tools.GitVersion.GitVersion;
using NukeBuild = NC::Nuke.Common.NukeBuild;
using Solution = NC::Nuke.Common.ProjectModel.Solution;
using Target = NC::Nuke.Common.Target;

namespace _build;

class Build : NukeBuild
{
    [NC::Nuke.Common.ProjectModel.SolutionAttribute]
    public Solution Solution;

    [NC::Nuke.Common.Tools.GitVersion.GitVersionAttribute]
    public GitVersion GitVersion;

    public static int Main() => Execute<Build>(x => x.Compile);

    [NC::Nuke.Common.ParameterAttribute(
        "Configuration to build - Default is 'Debug' (local) or 'Release' (server)"
    )]
    readonly Configuration Configuration = IsLocalBuild
        ? Configuration.Debug
        : Configuration.Release;

    [NC::Nuke.Common.ParameterAttribute("GIT message commit.")]
    readonly string CommitMessage;

    Target GitCommit =>
        _ =>
            _.DependsOn(Refactoring)
                .Executes(() =>
                {
                    var solutionDirectory = new DirectoryInfo(Solution.Directory.ThrowIfNull());
                    CommitMessage.ThrowIfNullOrWhiteSpace();
                    using var repository = new Repository(solutionDirectory.FullName);
                    var status = repository.RetrieveStatus();
                    status.ThrowIfNotHasChanges(solutionDirectory);
                    status.LogStatus();
                    var signature = repository.GetCurrentSignature();
                    repository.Stage("*").Commit(CommitMessage, signature, signature);
                    Log.Information("Commited");
                    status.LogStatus();
                });

    Target Refactoring =>
        _ =>
            _.Executes(async () =>
            {
                var output = new StringBuilder();
                output.Append(Environment.NewLine);
                var errorOutput = new StringBuilder();
                errorOutput.Append(Environment.NewLine);
                var directory = Solution.Directory.ThrowIfNull();

                await Cli.Wrap("dotnet")
                    .WithWorkingDirectory(directory)
                    .WithArguments("csharpier ./")
                    .WithStandardOutputPipe(PipeTarget.ToStringBuilder(output))
                    .WithStandardErrorPipe(PipeTarget.ToStringBuilder(errorOutput))
                    .ExecuteAsync();

                var errorOutputString = errorOutput.ToString();
                var outputString = output.ToString();

                if (!string.IsNullOrWhiteSpace(errorOutputString))
                {
                    Log.Error(errorOutputString);
                }

                if (!string.IsNullOrWhiteSpace(outputString))
                {
                    Log.Information(outputString);
                }
            });

    Target Clean =>
        _ =>
            _.DependsOn(Restore)
                .Executes(() =>
                {
                    DotNetClean(_ => _.SetConfiguration(Configuration));
                });

    Target Restore =>
        _ =>
            _.DependsOn(Refactoring)
                .Executes(() =>
                {
                    DotNetRestore();
                });

    Target Test =>
        _ =>
            _.DependsOn(Compile)
                .Executes(() =>
                {
                    DotNetTest(
                        _ =>
                            _.EnableNoRestore()
                                .EnableNoBuild()
                                .EnableNoRestore()
                                .SetConfiguration(Configuration)
                    );
                });

    Target Compile =>
        _ =>
            _.DependsOn(Clean)
                .Executes(() =>
                {
                    DotNetBuild(_ => _.EnableNoRestore().SetConfiguration(Configuration));
                });
}
