using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;
namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Layer;

public interface IExpenseRepository : IBaseRepository<Expense>
{
    Task<IList<Expense>> GetExpenseByCategory(string category);
    Task<int> GetExpenseByDate(DateTime startDate, DateTime endDate);
}