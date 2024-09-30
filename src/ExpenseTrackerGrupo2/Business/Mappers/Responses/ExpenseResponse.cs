using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;

public record ExpenseResponse
(
    decimal Amount,
    string Description,
    string Category,
    DateTime expense_date
)
{
    public static ExpenseResponse FromDomain(Expense expense)
    {
        return new ExpenseResponse
        (
            expense.Amount,
            expense.Description,
            expense.Category,
            expense.expense_date
        );
    }
}
