using ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;
using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public interface IBudgetRepository : IBaseRepository<Budget>
{
    Task<bool> SetBudget(Budget budget);
    Task<BudgetResponse> GetBudgetByUserIdAndMonth(Guid userId, string month, int year);
}
