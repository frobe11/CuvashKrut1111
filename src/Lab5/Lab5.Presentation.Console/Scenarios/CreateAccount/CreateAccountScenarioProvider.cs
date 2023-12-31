using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Models;
using Lab5.Application.Services.Contracts.BankAccount;
using Lab5.Application.Services.Contracts.UserRole;

namespace Lab5.Presentation.Console.Scenarios.CreateAccount;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly ICreateBankAccountService _createBankAccountService;
    private readonly string _scenarioName;
    private readonly ICurrentUserService _currentUserService;

    public CreateAccountScenarioProvider(
        ICreateBankAccountService createBankAccountService,
        string scenarioName,
        ICurrentUserService currentUserService)
    {
        _createBankAccountService = createBankAccountService;
        _scenarioName = scenarioName;
        _currentUserService = currentUserService;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUserService.User != UserRole.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new CreateAccountScenario(_createBankAccountService, _scenarioName);
        return true;
    }
}