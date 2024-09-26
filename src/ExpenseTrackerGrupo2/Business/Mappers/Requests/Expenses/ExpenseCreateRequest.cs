using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Expenses;

public record ExpenseCreateRequest
(
    decimal Amount,
    string Description,
    string Category,
    DateTime Date
)
{
    public Expense ToModel()
    {
        return new Expense
        {
            expense_id = Guid.NewGuid(),
            user_id = Guid.NewGuid(),
            Amount = Amount,
            Description = Description,
            Category = Category,
            expense_date = DateTime.UtcNow
        };
    }
}
