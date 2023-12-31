using Npgsql;

namespace Lab5.Infrastructure.ConnectionProvider;

public class ConnectionProvider : IConnectionProvider
{
    public ConnectionProvider(string connectionString)
    {
        Source = NpgsqlDataSource.Create(connectionString);
    }

    public NpgsqlDataSource Source { get; }
}