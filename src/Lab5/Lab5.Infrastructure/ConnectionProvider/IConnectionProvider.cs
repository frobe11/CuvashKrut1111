using Npgsql;

namespace Lab5.Infrastructure.ConnectionProvider;

public interface IConnectionProvider
{
    NpgsqlDataSource Source { get; }
}