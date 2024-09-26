using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Expenses;

public record ExpenseUpdateRequest
(
    decimal Amount,
    string Description,
    string Category,
    DateTime Date,
    Guid expense_id,
    Guid user_id
)
{
    public Expense ToModel()
    {
        return new Expense
        {
            user_id = user_id, 
            expense_id = expense_id,
            Amount = Amount,
            Description = Description,
            Category = Category,
            expense_date = Date            
        };
    }
}
