namespace Lab5.Application.Services.Contracts.BankAccount;

public interface IBankAccountMoneyOperationService
{
    OperationResult Withdraw(double amount, ICurrentBankAccountService currentBankAccountService);
    OperationResult Deposit(double amount, ICurrentBankAccountService currentBankAccountService);
}