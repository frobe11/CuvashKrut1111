using Lab5.Application.Repository;
using Lab5.Application.Services.Contracts.TransactionHistory;

namespace Lab5.Application.Services.TransactionHistory;

public class TransactionHistoryService : ITransactionHistoryService
{
    private ITransactionHistoryRepository _repository;

    public TransactionHistoryService(ITransactionHistoryRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Models.TransactionHistory> GetAllHistoryByAccountId(int accountId)
    {
        return _repository.GetAllHistoryByAccountId(accountId).Result;
    }
}