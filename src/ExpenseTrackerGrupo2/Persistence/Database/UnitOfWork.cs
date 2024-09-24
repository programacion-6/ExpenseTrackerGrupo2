namespace ExpenseTrackerGrupo2.Persistence.Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly NpgsqlConnectionFactory _npgsqlConnectionFactory;

    public UnitOfWork(NpgsqlConnectionFactory npgsqlConnectionFactory)
    {
        _npgsqlConnectionFactory = npgsqlConnectionFactory;
    }

    private void Init()
    {

    }

    public void BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public void Commit()
    {
        throw new NotImplementedException();
    }

    public void CommitAndCloseConnection()
    {
        throw new NotImplementedException();
    }

    public void RollBack()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
