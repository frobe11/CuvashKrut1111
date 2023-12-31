using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Services.Contracts.BankAccount;
using Lab5.Application.Services.Contracts.TransactionHistory;

namespace Lab5.Presentation.Console.Scenarios.ViewHistory;

public class ViewHistoryScenarioProvider : IScenarioProvider
{
    private readonly ICurrentBankAccountService _currentAccountService;
    private readonly ITransactionHistoryService _historyService;
    private readonly string _scenarioName;

    public ViewHistoryScenarioProvider(ICurrentBankAccountService currentAccountService, ITransactionHistoryService historyService, string scenarioName)
    {
        _currentAccountService = currentAccountService;
        _historyService = historyService;
        _scenarioName = scenarioName;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentAccountService.Account is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ViewHistoryScenario(_historyService, _currentAccountService, _scenarioName);
        return true;
    }
}