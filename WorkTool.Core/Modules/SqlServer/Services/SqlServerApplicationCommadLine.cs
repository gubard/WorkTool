﻿namespace WorkTool.Core.Modules.SqlServer.Services;

public class SqlServerApplicationCommadLine : IApplicationCommadLine
{
    private readonly CommandLineContext commandLineContext;

    public SqlServerApplicationCommadLine()
    {
        var parser  = new CommandLineArgumentParser();
        var builder = new CommandLineContextBuilder(parser);
        commandLineContext = builder.Build();
    }

    public bool Contains(string[] args)
    {
        var names = commandLineContext.GetTokens(args)
            .OfType<NameCommandLineToken>()
            .Select(x => x.Name)
            .ToArray();

        return commandLineContext.Contains(names);
    }

    public Task RunAsync(string[] args)
    {
        return commandLineContext.RunAsync(args);
    }
}