using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Expenses;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;

namespace ExpenseTrackerGrupo2.Business.Services.Interfaces;

public interface IExpenseService
{
    Task<IList<ExpenseResponse>> GetAllExpenses();
    Task<IList<ExpenseResponse>> GetExpenses(DateTime? startDate, DateTime? endDate, string? category);
    Task<ExpenseResponse> GetExpenseById(Guid expenseId);
    Task<string> GetHighestSpendingCategory();
    Task<int> CreateExpense(ExpenseCreateRequest expense);
    Task<int> UpdateExpense(ExpenseUpdateRequest expense, Guid id);
    Task<bool> DeleteExpense(Guid expenseId);
}
