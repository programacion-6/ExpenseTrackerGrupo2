namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public interface IBaseRepository<T>
{
    Task<IList<T>> GetAll();
    Task<T> GetById(Guid id);
    Task<int> Create(T entity);
    Task<int> Update(T entity);
    Task<bool> Delete(Guid id);
}
