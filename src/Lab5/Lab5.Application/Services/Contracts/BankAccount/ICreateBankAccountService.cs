namespace Lab5.Application.Services.Contracts.BankAccount;

public interface ICreateBankAccountService
{
    OperationResult Create(Models.BankAccount bankAccount);
}