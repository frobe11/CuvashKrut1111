using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Models;
using Lab5.Application.Services.Contracts.UserRole;

namespace Lab5.Presentation.Console.Scenarios.AdminLogin;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserRoleService _adminVerificationService;
    private readonly string _scenarioName;

    public AdminLoginScenarioProvider(
        ICurrentUserService currentUserService,
        IUserRoleService adminVerificationService,
        string scenarioName)
    {
        _currentUserService = currentUserService;
        _adminVerificationService = adminVerificationService;
        _scenarioName = scenarioName;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUserService.User != UserRole.None)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_scenarioName, _currentUserService, _adminVerificationService);
        return true;
    }
}