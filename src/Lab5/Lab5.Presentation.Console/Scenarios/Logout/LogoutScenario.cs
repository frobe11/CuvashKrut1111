using Lab5.Application.Models;
using Lab5.Application.Services.Contracts.BankAccount;
using Lab5.Application.Services.Contracts.UserRole;

namespace Lab5.Presentation.Console.Scenarios.Logout;

public class LogoutScenario : IScenario
{
    private readonly ICurrentBankAccountService _currentBankService;
    private readonly ICurrentUserService _currentUserService;

    public LogoutScenario(ICurrentBankAccountService currentBankService, ICurrentUserService currentUserService, string name)
    {
        _currentBankService = currentBankService;
        _currentUserService = currentUserService;
        Name = name;
    }

    public string Name { get; }
    public void Run()
    {
        _currentBankService.Account = null;
        _currentUserService.User = UserRole.None;
    }
}