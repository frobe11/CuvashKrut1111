using Lab5.Application.Services.Contracts;
using Lab5.Application.Services.Contracts.BankAccount;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IBankAccountMoneyOperationService _moneyOperationService;
    private readonly ICurrentBankAccountService _currentAccountService;

    public WithdrawMoneyScenario(
        IBankAccountMoneyOperationService moneyOperationService,
        ICurrentBankAccountService currentAccountService,
        string name)
    {
        _moneyOperationService = moneyOperationService;
        _currentAccountService = currentAccountService;
        Name = name;
    }

    public string Name { get; }

    public void Run()
    {
        int amount = AnsiConsole.Ask<int>("Enter amount you want to withdraw");
        OperationResult result = _moneyOperationService.Withdraw(amount, _currentAccountService);
        string message = result switch
        {
            OperationResult.Success => "Money withdrawn",
            OperationResult.Failure failure => failure.What,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
    }
}