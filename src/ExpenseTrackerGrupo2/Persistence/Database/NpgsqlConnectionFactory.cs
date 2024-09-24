using System.Data;

using Npgsql;

namespace ExpenseTrackerGrupo2.Persistence.Database;

public class NpgsqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;
    private IDbConnection _connection;

    public NpgsqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        if (_connection is null || _connection.State != ConnectionState.Open)
        {
            _connection = new NpgsqlConnection(_connectionString);

            await ((NpgsqlConnection) _connection).OpenAsync();
        }

        return _connection;
    }

    public async Task<(IDbConnection connection, IDbTransaction transaction)> MakeTransactionAsync()
    {
        var connection = await CreateConnectionAsync();
        var transaction = connection.BeginTransaction();
        
        return (connection, transaction);
    }

    // public void Dispose()
    // {
    //     if (_connection != null || _connection.State == ConnectionState.Open)
    //     {
    //         _connection.Close();
    //         _connection.Dispose();
    //     }
    // }
}
