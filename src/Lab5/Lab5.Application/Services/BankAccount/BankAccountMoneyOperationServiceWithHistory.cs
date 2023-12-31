using Lab5.Application.Repository;
using Lab5.Application.Services.Contracts;
using Lab5.Application.Services.Contracts.BankAccount;

namespace Lab5.Application.Services.BankAccount;

public class BankAccountMoneyOperationServiceWithHistory : IBankAccountMoneyOperationService
{
    private ITransactionHistoryRepository _repository;
    private IBankAccountMoneyOperationService _service;

    public BankAccountMoneyOperationServiceWithHistory(
        ITransactionHistoryRepository repository,
        IBankAccountMoneyOperationService service)
    {
        _repository = repository;
        _service = service;
    }

    public OperationResult Withdraw(double amount, ICurrentBankAccountService currentBankAccountService)
    {
        if (currentBankAccountService.Account == null)
            return new OperationResult.Failure("no current bank account");
        OperationResult result = _service.Withdraw(amount, currentBankAccountService);
        if (result is OperationResult.Success)
        {
            _repository.Create(new Models.TransactionHistory(
                228,
                currentBankAccountService.Account.Id,
                amount * (-1)));
        }

        return result;
    }

    public OperationResult Deposit(double amount, ICurrentBankAccountService currentBankAccountService)
    {
        if (currentBankAccountService.Account == null)
            return new OperationResult.Failure("no current bank account");
        OperationResult result = _service.Deposit(amount, currentBankAccountService);
        if (result is OperationResult.Success)
        {
            _repository.Create(new Models.TransactionHistory(
                228,
                currentBankAccountService.Account.Id,
                amount));
        }

        return result;
    }
}