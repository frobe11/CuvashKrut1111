using Lab5.Application.Services.Contracts;
using Lab5.Application.Services.Contracts.BankAccount;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.DepositMoney;

public class DepositMoneyScenario : IScenario
{
    private readonly IBankAccountMoneyOperationService _moneyOperationService;
    private readonly ICurrentBankAccountService _currentAccountService;

    public DepositMoneyScenario(IBankAccountMoneyOperationService moneyOperationService, ICurrentBankAccountService currentAccountService, string name)
    {
        _moneyOperationService = moneyOperationService;
        _currentAccountService = currentAccountService;
        Name = name;
    }

    public string Name { get; }
    public void Run()
    {
        int amount = AnsiConsole.Ask<int>("Enter amount");
        OperationResult result = _moneyOperationService.Deposit(amount, _currentAccountService);
        string message = result switch
        {
            OperationResult.Success => "Money deposited",
            OperationResult.Failure failure => failure.What,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
    }
}