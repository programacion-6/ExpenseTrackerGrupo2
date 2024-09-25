using System.Data;

namespace ExpenseTrackerGrupo2.Persistence.Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;
    private bool _isDisposed;

    public UnitOfWork(IDbConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.CreateConnectionAsync().Result;
        _transaction = _connection.BeginTransaction();
    }

    public Task CommitAsync()
    {
        _transaction.Commit();
        _connection.Close();
        return Task.CompletedTask; 
    }

    public Task RollbackAsync()
    {
        _transaction.Rollback();
        _connection.Close();
        return Task.CompletedTask; 
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
                _transaction?.Dispose();
                _connection?.Dispose();
            }
            _isDisposed = true;
        }
    }
}
