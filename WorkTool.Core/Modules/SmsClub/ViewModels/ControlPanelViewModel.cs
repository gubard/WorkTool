namespace WorkTool.Core.Modules.SmsClub.ViewModels;

public class ControlPanelViewModel : ViewModelBase
{
    private readonly ISmsClubSender<object> smsClubSender;
    private double balance;
    private string? currency;
    private string? smsIds;
    private string? info;
    private string? selectedOriginator;
    private string? text;
    private string? phoneNumbers;

    public ControlPanelViewModel(
        IHumanizing<Exception, object> humanizing,
        IMessageBoxView messageBoxView,
        ISmsClubSender<object> smsClubSender
    ) : base(humanizing, messageBoxView)
    {
        this.smsClubSender = smsClubSender;
        Originators = new AvaloniaList<string>();
        UpdateBalanceCommand = CreateCommand(UpdateBalanceAsync);
        UpdateOriginatorsCommand = CreateCommand(UpdateOriginatorsAsync);
        GetSmsesStatusCommand = CreateCommand(GetSmsesStatusAsync);
        LoadedCommand = CreateCommand(RefreshAsync);
        RefreshCommand = CreateCommand(RefreshAsync);
        SendSmsCommand = CreateCommand(SendSmsAsync);
    }

    public double Balance
    {
        get => balance;
        set => this.RaiseAndSetIfChanged(ref balance, value);
    }

    public string? Currency
    {
        get => currency;
        set => this.RaiseAndSetIfChanged(ref currency, value);
    }

    public string? SmsIds
    {
        get => smsIds;
        set => this.RaiseAndSetIfChanged(ref smsIds, value);
    }

    public string? Info
    {
        get => info;
        set => this.RaiseAndSetIfChanged(ref info, value);
    }

    public string? SelectedOriginator
    {
        get => selectedOriginator;
        set => this.RaiseAndSetIfChanged(ref selectedOriginator, value);
    }

    public string? Text
    {
        get => text;
        set => this.RaiseAndSetIfChanged(ref text, value);
    }

    public string? PhoneNumbers
    {
        get => phoneNumbers;
        set => this.RaiseAndSetIfChanged(ref phoneNumbers, value);
    }

    public AvaloniaList<string> Originators { get; }
    public ICommand LoadedCommand { get; }
    public ICommand RefreshCommand { get; }
    public ICommand UpdateBalanceCommand { get; }
    public ICommand UpdateOriginatorsCommand { get; }
    public ICommand GetSmsesStatusCommand { get; }
    public ICommand SendSmsCommand { get; }

    private Task RefreshAsync()
    {
        return Task.WhenAll(UpdateBalanceAsync(), UpdateOriginatorsAsync());
    }

    private async Task GetSmsesStatusAsync()
    {
        var smsIdsString = SmsIds.ThrowIfNullOrWhiteSpace();
        var smsIds = smsIdsString.Split(',').Select(x => x.Trim());
        var status = await smsClubSender.GetSmsStatusAsync(smsIds);

        Info = Info.AddLine(
            status.SuccessRequest
                .ThrowIfNull()
                .Info.ThrowIfNull()
                .Select(x => $"{x.Key}: {x.Value}")
                .JoinString(Environment.NewLine)
        );
    }

    private async Task SendSmsAsync()
    {
        PhoneNumbers = PhoneNumbers.ThrowIfNull();

        var response = await smsClubSender.SendSmsAsync(
            new SendSmsRequest()
            {
                Recipient = SelectedOriginator,
                Message = Text,
                PhoneNumbers = PhoneNumbers.Split(',')
            }
        );

        Info = Info.AddLine(response.ToJson());
    }

    private async Task UpdateBalanceAsync()
    {
        var balanceResponse = await smsClubSender.GetBalanceAsync();
        var obj = balanceResponse.SuccessRequest.ThrowIfNull().Object.ThrowIfNull();
        Balance = obj.Money;
        Currency = obj.Currency;
    }

    private async Task UpdateOriginatorsAsync()
    {
        var originators = await smsClubSender.GetOriginatorsAsync();
        Originators.Update(originators.SuccessRequest.ThrowIfNull().Info.ThrowIfNull());
    }
}
