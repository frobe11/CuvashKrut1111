using Lab5.Application.Services.Contracts.BankAccount;

namespace Lab5.Application.Services.BankAccount;

public class CurrentBankAccountManager : ICurrentBankAccountService
{
    public Models.BankAccount? Account { get; set; }
}