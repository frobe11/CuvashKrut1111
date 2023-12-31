using Lab5.Application.Repository;
using Lab5.Application.Services.Contracts;
using Lab5.Application.Services.Contracts.BankAccount;

namespace Lab5.Application.Services.BankAccount;

public class BankAccountService : ICreateBankAccountService, IUpdateBankAccountService
{
    private IBankAccountRepository _repository;
    public BankAccountService(IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public OperationResult Create(Models.BankAccount bankAccount)
    {
        RepositoryRequestResult result = _repository.Create(bankAccount).Result;
        return result switch
        {
            RepositoryRequestResult.Failure failure => new OperationResult.Failure(failure.What),
            RepositoryRequestResult.Success => new OperationResult.Success(),
            _ => new OperationResult.Failure("something went wrong"),
        };
    }

    public OperationResult Update(Models.BankAccount bankAccount)
    {
        RepositoryRequestResult result = _repository.Update(bankAccount).Result;
        return result switch
        {
            RepositoryRequestResult.Failure failure => new OperationResult.Failure(failure.What),
            RepositoryRequestResult.Success => new OperationResult.Success(),
            _ => new OperationResult.Failure("something went wrong"),
        };
    }
}