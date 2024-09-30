using ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;
using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public interface IExpenseRepository : IBaseRepository<Expense>
{
    Task<IList<ExpenseResponse>> GetExpenseByCategory(string category);
    Task<int> GetExpenseByDate(DateTime startDate, DateTime endDate);
}
