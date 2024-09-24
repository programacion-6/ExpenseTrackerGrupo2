using System.Data;

namespace ExpenseTrackerGrupo2.Persistence.Database;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
    Task<(IDbConnection connection, IDbTransaction transaction)> MakeTransactionAsync();
}
