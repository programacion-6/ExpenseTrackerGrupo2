using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Budgets;
using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Interfaces;

public interface IBudgetService
{
    Task<Budget> GetBudgetById(Guid id);
    Task<IList<Budget>> GetAllBudgets();
    Task<Budget> CreateBudget(BudgetCreateRequest request);
    Task<Budget> UpdateBudget(BudgetUpdateRequest request, Guid id);
    Task<bool> DeleteBudget(Guid id);
}
