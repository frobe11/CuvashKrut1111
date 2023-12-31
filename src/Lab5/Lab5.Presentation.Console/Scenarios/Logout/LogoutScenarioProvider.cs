using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Models;
using Lab5.Application.Services.Contracts.BankAccount;
using Lab5.Application.Services.Contracts.UserRole;

namespace Lab5.Presentation.Console.Scenarios.Logout;

public class LogoutScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly ICurrentBankAccountService _currentBankService;
    private readonly string _scenarioName;

    public LogoutScenarioProvider(
        ICurrentUserService currentUserService,
        ICurrentBankAccountService currentBankService,
        string scenarioName)
    {
        _currentUserService = currentUserService;
        _currentBankService = currentBankService;
        _scenarioName = scenarioName;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUserService.User == UserRole.None)
        {
            scenario = null;
            return false;
        }

        scenario = new LogoutScenario(_currentBankService, _currentUserService, _scenarioName);
        return true;
    }
}