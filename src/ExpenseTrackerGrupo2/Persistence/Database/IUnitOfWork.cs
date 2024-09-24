namespace ExpenseTrackerGrupo2.Persistence.Database;

public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();
    void Commit();
    void CommitAndCloseConnection();
    void RollBack();
}
