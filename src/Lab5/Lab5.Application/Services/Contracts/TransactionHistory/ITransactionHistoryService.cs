namespace Lab5.Application.Services.Contracts.TransactionHistory;

public interface ITransactionHistoryService
{
    IEnumerable<Models.TransactionHistory> GetAllHistoryByAccountId(int accountId);
}