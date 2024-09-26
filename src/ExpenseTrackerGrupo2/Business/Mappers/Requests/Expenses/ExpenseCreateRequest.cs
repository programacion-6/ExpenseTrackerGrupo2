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
        Console.WriteLine($"Creating Expense with Date: {Date}");
        return new Expense
        {
            expense_id = Guid.NewGuid(),
            user_id = UserId,
            Amount = Amount,
            Description = Description,
            Category = Category,
            expense_date = Date
        };
    }
}
