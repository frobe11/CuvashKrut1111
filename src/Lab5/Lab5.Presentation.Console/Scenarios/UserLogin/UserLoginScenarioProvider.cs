using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Models;
using Lab5.Application.Services.Contracts.BankAccount;
using Lab5.Application.Services.Contracts.UserRole;

namespace Lab5.Presentation.Console.Scenarios.UserLogin;

public class UserLoginScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountVerificationService _bankAccountVerificationService;
    private readonly ICurrentBankAccountService _currentBankAccountService;
    private readonly ICurrentUserService _currentUserService;
    private readonly string _scenarioName;

    public UserLoginScenarioProvider(
        IBankAccountVerificationService bankAccountVerificationService,
        ICurrentBankAccountService currentBankAccountService,
        ICurrentUserService currentUserService,
        string scenarioName)
    {
        _bankAccountVerificationService = bankAccountVerificationService;
        _currentBankAccountService = currentBankAccountService;
        _currentUserService = currentUserService;
        _scenarioName = scenarioName;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User != UserRole.None)
        {
            scenario = null;
            return false;
        }

        scenario = new UserLoginScenario(
            _scenarioName,
            _bankAccountVerificationService,
            _currentBankAccountService,
            _currentUserService);
        return true;
    }
}