using Lab5.Application.Models;

namespace Lab5.Application.Repository;

public interface ITransactionHistoryRepository : IRepository<TransactionHistory>
{
    Task<IEnumerable<TransactionHistory>> GetAllHistoryByAccountId(int accountId);
}