using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public interface IBudgetRepository : IBaseRepository<Budget>
{
    Task<bool> SetBudget(Budget budget);
    Task<Budget> GetBudgetByUserIdAndMonth(Guid userId, int month, int year);
}
