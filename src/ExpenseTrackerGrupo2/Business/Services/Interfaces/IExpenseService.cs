using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Expenses;
using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Interfaces;

public interface IExpenseService
{
    // TODO: Update according VOs
    Task<IList<Expense>> GetAllExpenses();
    Task<Expense> GetExpenseById(Guid expenseId);
    Task<int> CreateExpense(ExpenseCreateRequest expense);
    Task<int> UpdateExpense(ExpenseUpdateRequest expense);
    Task<bool> DeleteExpense(Guid expenseId);
}
