using Lab5.Application.Models;
using Lab5.Application.Services.Contracts;
using Lab5.Application.Services.Contracts.BankAccount;
using Lab5.Application.Services.Contracts.UserRole;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.UserLogin;

public class UserLoginScenario : IScenario
{
    private ICurrentBankAccountService _currentBankAccountService;
    private ICurrentUserService _currentUserService;
    private IBankAccountVerificationService _accountVerificationService;
    public UserLoginScenario(string name, IBankAccountVerificationService accountVerificationService, ICurrentBankAccountService currentBankAccountServic, ICurrentUserService currentUserService)
    {
        Name = name;
        _accountVerificationService = accountVerificationService;
        _currentBankAccountService = currentBankAccountServic;
        _currentUserService = currentUserService;
    }

    public string Name { get; }
    public void Run()
    {
        int id = AnsiConsole.Ask<int>("Enter account id");
        string password = AnsiConsole.Ask<string>("Enter pin");
        OperationResult result = _accountVerificationService.Verify(id, password, _currentBankAccountService);
        switch (result)
        {
            case OperationResult.Failure failure:
                AnsiConsole.WriteLine(failure.What);
                break;
            case OperationResult.Success:
                _currentUserService.User = UserRole.User;
                AnsiConsole.WriteLine("Successful log in");
                break;
        }
    }
}