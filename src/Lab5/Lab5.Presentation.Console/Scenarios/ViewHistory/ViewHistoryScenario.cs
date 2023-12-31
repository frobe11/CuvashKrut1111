using System.Globalization;
using Lab5.Application.Models;
using Lab5.Application.Services.Contracts.BankAccount;
using Lab5.Application.Services.Contracts.TransactionHistory;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ViewHistory;

public class ViewHistoryScenario : IScenario
{
    private readonly ICurrentBankAccountService _currentAccountService;
    private readonly ITransactionHistoryService _historyService;

    public ViewHistoryScenario(
        ITransactionHistoryService historyService,
        ICurrentBankAccountService currentAccountService,
        string name)
    {
        _historyService = historyService;
        _currentAccountService = currentAccountService;
        Name = name;
    }

    public string Name { get; }
    public void Run()
    {
        if (_currentAccountService.Account == null)
            throw new ArgumentNullException(nameof(_currentAccountService.Account));
        IEnumerable<TransactionHistory> history = _historyService.GetAllHistoryByAccountId(_currentAccountService.Account.Id);
        AnsiConsole.WriteLine("Transaction history: ");
        foreach (TransactionHistory transaction in history)
        {
            AnsiConsole.WriteLine(new NumberFormatInfo(), transaction.Amount);
        }
    }
}