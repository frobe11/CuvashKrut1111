using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Services.Contracts.BankAccount;

namespace Lab5.Presentation.Console.Scenarios.ViewBalance;

public class ViewBalanceScenarioProvider : IScenarioProvider
{
    private readonly ICurrentBankAccountService _currentBankAccountService;
    private readonly string _scenarioName;

    public ViewBalanceScenarioProvider(ICurrentBankAccountService currentBankAccountService, string scenarioName)
    {
        _currentBankAccountService = currentBankAccountService;
        _scenarioName = scenarioName;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentBankAccountService.Account == null)
        {
            scenario = null;
            return false;
        }

        scenario = new ViewBalanceScenario(
            _currentBankAccountService,
            _scenarioName);
        return true;
    }
}