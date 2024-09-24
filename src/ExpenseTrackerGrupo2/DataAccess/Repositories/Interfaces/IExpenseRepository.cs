using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public interface IExpenseRepository : IBaseRepository<Expense>
{
    Task<IList<Expense>> GetExpenseByCategory(string category);
    Task<int> GetExpenseByDate(DateTime startDate, DateTime endDate);
}
