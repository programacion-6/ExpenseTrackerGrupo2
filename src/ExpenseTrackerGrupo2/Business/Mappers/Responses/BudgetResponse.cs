using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;

public record BudgetResponse
(
    decimal BudgetAmount,
    DateTime Month
)
{
    public static BudgetResponse FromDomain(Budget budget)
    {
        return new BudgetResponse
        (
            budget.budget_amount,
            budget.Month
        );
    }
}
