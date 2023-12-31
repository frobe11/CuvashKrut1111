using Lab5.Application.Models;
using Lab5.Application.Repository;
using Lab5.Infrastructure.ConnectionProvider;
using Npgsql;

namespace Lab5.Infrastructure.Repository;

public class TransactionHistoryRepository : ITransactionHistoryRepository
{
    private IConnectionProvider _connection;
    public TransactionHistoryRepository(IConnectionProvider connection)
    {
        _connection = connection;
    }

    public async Task<TransactionHistory?> GetById(int id)
    {
        await using NpgsqlCommand command = _connection.Source.CreateCommand($"SELECT distinct id, bankAccountId, amount FROM Transactions WHERE id = {id}");
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
            return null;
        return new TransactionHistory(
            reader.GetInt32(0),
            reader.GetInt32(1),
            reader.GetDouble(2));
    }

    public async Task<RepositoryRequestResult> Create(TransactionHistory obj)
    {
        await using NpgsqlCommand command1 =
            _connection.Source.CreateCommand($"SELECT FROM Transactions WHERE id = {obj.Id}");
        await using NpgsqlDataReader reader = await command1.ExecuteReaderAsync();
        if (await reader.ReadAsync())
            return new RepositoryRequestResult.Failure("same id already exists");

        await using NpgsqlCommand command =
            _connection.Source.CreateCommand($"INSERT INTO Transactions (bankAccountId, amount) VALUES ({obj.BankAccountId}, {obj.Amount})");
        await command.ExecuteNonQueryAsync();
        return new RepositoryRequestResult.Success();
    }

    public async Task<RepositoryRequestResult> Delete(int id)
    {
        await using NpgsqlCommand command1 =
            _connection.Source.CreateCommand($"SELECT FROM Transactions WHERE id = {id}");
        await using NpgsqlDataReader reader = await command1.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
            return new RepositoryRequestResult.Failure("id does not exists");

        await using NpgsqlCommand command2 =
            _connection.Source.CreateCommand($"DELETE FROM Transactions WHERE id = {id}");
        await command2.ExecuteNonQueryAsync();
        return new RepositoryRequestResult.Success();
    }

    public async Task<IEnumerable<TransactionHistory>> GetAllHistoryByAccountId(int accountId)
    {
        await using NpgsqlCommand command =
            _connection.Source.CreateCommand($"SELECT id, bankAccountId, amount FROM Transactions WHERE bankAccountId = {accountId}");
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        var history = new List<TransactionHistory>();
        while (await reader.ReadAsync())
        {
            history.Add(new TransactionHistory(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetDouble(2)));
        }

        return history;
    }
}