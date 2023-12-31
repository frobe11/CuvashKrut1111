namespace Lab5.Application.Services.Contracts.BankAccount;

public interface IUpdateBankAccountService
{
    OperationResult Update(Models.BankAccount bankAccount);
}