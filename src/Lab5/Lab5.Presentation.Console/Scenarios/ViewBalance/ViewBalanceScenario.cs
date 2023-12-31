using Lab5.Application.Services.Contracts.BankAccount;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ViewBalance;

public class ViewBalanceScenario : IScenario
{
    private readonly ICurrentBankAccountService _currentAccountService;

    public ViewBalanceScenario(ICurrentBankAccountService currentAccountService, string name)
    {
        _currentAccountService = currentAccountService;
        Name = name;
    }

    public string Name { get; }
    public void Run()
    {
        if (_currentAccountService.Account == null)
            throw new ArgumentNullException(nameof(_currentAccountService.Account));
        AnsiConsole.WriteLine($"balance: ${_currentAccountService.Account.Balance}");
    }
}