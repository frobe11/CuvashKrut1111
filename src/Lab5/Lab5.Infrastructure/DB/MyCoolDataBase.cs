using Lab5.Infrastructure.ConnectionProvider;
using Npgsql;

namespace Lab5.Infrastructure.DB;

public class MyCoolDataBase : IDataBase
{
    private IConnectionProvider _connection;

    public MyCoolDataBase(IConnectionProvider connection)
    {
        _connection = connection;
    }

    public async Task SetUp()
    {
        await using NpgsqlCommand command = _connection.Source.CreateCommand("""
        CREATE TABLE IF NOT EXISTS BankAccounts  (
        id int primary key,
        pin varchar(100) not null,
        balance double precision not null);
        CREATE TABLE IF NOT EXISTS Transactions (
        id int primary key generated always as identity,
        bankAccountId int not null references BankAccounts (id) on delete cascade on update cascade,
        amount double precision not null);
""");
        await command.ExecuteNonQueryAsync();
    }

    public async Task TearDown()
    {
        await using NpgsqlCommand command = _connection.Source.CreateCommand("""
        DROP TABLE IF EXISTS BankAccounts;
        DROP TABLE IF EXISTS Transactions;
""");
        await command.ExecuteNonQueryAsync();
    }
}