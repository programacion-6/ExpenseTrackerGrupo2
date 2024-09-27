namespace ExpenseTrackerGrupo2.Persistence.Database;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
    Task RollbackAsync();
}
