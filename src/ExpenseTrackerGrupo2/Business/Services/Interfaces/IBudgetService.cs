using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Budgets;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;

namespace ExpenseTrackerGrupo2.Business.Services.Interfaces;

public interface IBudgetService
{
    Task<IList<BudgetResponse>> GetAllBudgets();
    Task<BudgetResponse> GetBudgetById(Guid id);
    Task<int> CreateBudget(BudgetCreateRequest request);
    Task<int> UpdateBudget(BudgetUpdateRequest request, Guid id);
    Task<bool> DeleteBudget(Guid id);
}
