using System.Data;
using Lab5.Application.Models;
using Lab5.Application.Services.Contracts;
using Lab5.Application.Services.Contracts.UserRole;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminLogin;

public class AdminLoginScenario : IScenario
{
    private ICurrentUserService _currentUserService;
    private IUserRoleService _adminVerificationService;
    public AdminLoginScenario(string name, ICurrentUserService currentUserService, IUserRoleService adminVerificationService)
    {
        _currentUserService = currentUserService;
        _adminVerificationService = adminVerificationService;
        Name = name;
    }

    public string Name { get; }
    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter admin password");

        OperationResult result = _adminVerificationService.VerifyAdmin(password);

        string message = result switch
        {
            OperationResult.Success => "Successful login",
            OperationResult.Failure failure => throw new InvalidExpressionException(failure.What),
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        _currentUserService.User = UserRole.Admin;

        AnsiConsole.WriteLine(message);
    }
}