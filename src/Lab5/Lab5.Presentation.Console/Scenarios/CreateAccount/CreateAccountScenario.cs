using Lab5.Application.Models;
using Lab5.Application.Services.Contracts;
using Lab5.Application.Services.Contracts.BankAccount;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CreateAccount;

public class CreateAccountScenario : IScenario
{
    private ICreateBankAccountService _createBankAccountService;

    public CreateAccountScenario(ICreateBankAccountService createBankAccountService, string name)
    {
        _createBankAccountService = createBankAccountService;
        Name = name;
    }

    public string Name { get; }
    public void Run()
    {
        int id = AnsiConsole.Ask<int>("Enter account id");
        string pin = AnsiConsole.Ask<string>("Enter pin");
        OperationResult result = _createBankAccountService.Create(new BankAccount(id, pin, 0));
        string message = result switch
        {
            OperationResult.Success => "Account created",
            OperationResult.Failure failure => failure.What,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
    }
}