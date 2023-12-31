namespace Lab5.Application.Services.Contracts.BankAccount;

public interface ICurrentBankAccountService
{
    Models.BankAccount? Account { get; set; }
}