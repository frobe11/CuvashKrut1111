using Lab5.Application.Models;
using Lab5.Application.Repository;
using Lab5.Infrastructure.ConnectionProvider;
using Npgsql;

namespace Lab5.Infrastructure.Repository;

public class BankAccountRepository : IBankAccountRepository
{
    private IConnectionProvider _connection;

    public BankAccountRepository(IConnectionProvider connection)
    {
        _connection = connection;
    }

    public async Task<BankAccount?> GetById(int id)
    {
        await using NpgsqlCommand command = _connection.Source.CreateCommand($"SELECT distinct id, pin, balance FROM BankAccounts WHERE id = {id}");
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
            return null;
        return new BankAccount(
            reader.GetInt32(0),
            reader.GetString(1),
            reader.GetDouble(2));
    }

    public async Task<RepositoryRequestResult> Create(BankAccount obj)
    {
        await using NpgsqlCommand command1 = _connection.Source.CreateCommand($"SELECT id FROM BankAccounts WHERE id = {obj.Id}");
        await using NpgsqlDataReader reader = await command1.ExecuteReaderAsync();
        if (await reader.ReadAsync())
            return new RepositoryRequestResult.Failure("same id already exists");

        await using NpgsqlCommand command2 = _connection.Source.CreateCommand($"INSERT INTO BankAccounts (id, pin, balance) VALUES ({obj.Id}, '{obj.Pin}', {obj.Balance})");
        await command2.ExecuteNonQueryAsync();
        return new RepositoryRequestResult.Success();
    }

    public async Task<RepositoryRequestResult> Delete(int id)
    {
        await using NpgsqlCommand command1 = _connection.Source.CreateCommand($"SELECT id FROM BankAccounts WHERE id = {id}");
        await using NpgsqlDataReader reader = await command1.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
            return new RepositoryRequestResult.Failure("same id doesn't exists");

        await using NpgsqlCommand command2 = _connection.Source.CreateCommand($"DELETE FROM BankAccounts where id = {id}");
        await command2.ExecuteNonQueryAsync();
        return new RepositoryRequestResult.Success();
    }

    public async Task<RepositoryRequestResult> Update(BankAccount obj)
    {
        await using NpgsqlCommand command1 = _connection.Source.CreateCommand($"SELECT id FROM BankAccounts WHERE id = {obj.Id}");
        await using NpgsqlDataReader reader = await command1.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
            return new RepositoryRequestResult.Failure("same id doesn't exists");

        await using NpgsqlCommand command2 = _connection.Source.CreateCommand($"UPDATE BankAccounts SET pin = '{obj.Pin}', balance = {obj.Balance} WHERE id = {obj.Id}");
        await command2.ExecuteNonQueryAsync();
        return new RepositoryRequestResult.Success();
    }
}