using System.Data;

using Npgsql;

namespace ExpenseTrackerGrupo2.Persistence.Database;

public class NpgsqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public NpgsqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new NpgsqlConnection(_connectionString);

        await connection.OpenAsync();
        
        return connection;
    }

    public async Task<IDbTransaction> MakeTransactionAsync()
    {
        var connection = await CreateConnectionAsync();
        
        return connection.BeginTransaction();
    }
}
