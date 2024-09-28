using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Budgets;

public record BudgetUpdateRequest
(
    decimal BudgetAmount,
    DateTime Month
)
{
    public Budget ToModel()
    {
        return new Budget
        {
            budget_amount = BudgetAmount,
            Month = Month
        };
    }
}
