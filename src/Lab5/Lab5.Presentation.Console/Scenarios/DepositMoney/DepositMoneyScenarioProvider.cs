using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Services.Contracts.BankAccount;

namespace Lab5.Presentation.Console.Scenarios.DepositMoney;

public class DepositMoneyScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountMoneyOperationService _moneyOperationService;
    private readonly ICurrentBankAccountService _currentAccountService;
    private readonly string _scenarioName;

    public DepositMoneyScenarioProvider(
        IBankAccountMoneyOperationService moneyOperationService,
        ICurrentBankAccountService currentAccountService,
        string scenarioName)
    {
        _moneyOperationService = moneyOperationService;
        _currentAccountService = currentAccountService;
        _scenarioName = scenarioName;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentAccountService.Account is null)
        {
            scenario = null;
            return false;
        }

        scenario = new DepositMoneyScenario(_moneyOperationService, _currentAccountService, _scenarioName);
        return true;
    }
}