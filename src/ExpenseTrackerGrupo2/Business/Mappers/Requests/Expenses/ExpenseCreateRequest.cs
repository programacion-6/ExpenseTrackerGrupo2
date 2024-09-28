using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Expenses;

public record ExpenseCreateRequest
(
    decimal Amount,
    string Description,
    string Category,
    DateTime Date,
    Guid UserId
)
{
    public Expense ToModel()
    {
        return new Expense
        {
            Amount = Amount,
            Description = Description,
            Category = Category,
            expense_date = Date,
            user_id = UserId
        };
    }
}
