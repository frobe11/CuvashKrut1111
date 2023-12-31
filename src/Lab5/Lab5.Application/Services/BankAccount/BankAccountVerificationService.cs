using Lab5.Application.Repository;
using Lab5.Application.Services.Contracts;
using Lab5.Application.Services.Contracts.BankAccount;

namespace Lab5.Application.Services.BankAccount;

public class BankAccountVerificationService : IBankAccountVerificationService
{
    private IBankAccountRepository _repository;

    public BankAccountVerificationService(IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public OperationResult Verify(int accountId, string pin, ICurrentBankAccountService currentBankAccountService)
    {
        Models.BankAccount? account = _repository.GetById(accountId).Result;
        if (account == null)
            return new OperationResult.Failure("wrong id");
        if (account.Pin != pin)
            return new OperationResult.Failure("wrong pin");
        currentBankAccountService.Account = account;
        return new OperationResult.Success();
    }
}