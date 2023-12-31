namespace Lab5.Application.Services.Contracts.BankAccount;

public interface IBankAccountVerificationService
{
    OperationResult Verify(int accountId, string pin, ICurrentBankAccountService currentBankAccountService);
}