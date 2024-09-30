using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;

public record GoalResponse
(
    decimal GoalAmount,
    DateTime Deadline,
    decimal CurrentAmount
)
{
    public static GoalResponse FromDomain(Goal goal)
    {
        return new GoalResponse
        (
            goal.goal_amount,
            goal.Deadline,
            goal.current_amount
        );
    }
}
