using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Budgets;

public record BudgetUpdateRequest
(
    decimal BudgetAmount,
    DateTime Month,
    Guid User_id
)
{
    public Budget ToModel()
    {
        return new Budget
        {
            budget_amount = BudgetAmount,
            month = Month,
            user_id = User_id
        };
    }
}
