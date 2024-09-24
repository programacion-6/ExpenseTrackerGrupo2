using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Budgets;

public record BudgetCreateRequest
(
    decimal BudgetAmount,
    DateTime Month
)
{
    public Budget ToModel()
    {
        return new Budget
        {
            BudgetAmount = BudgetAmount,
            Month = Month
        };
    }
}
