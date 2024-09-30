using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Goals;

public record GoalUpdateRequest
(
    decimal GoalAmount,
    DateTime Deadline,
    decimal CurrentAmount,
    Guid UserId
)
{ 
    public Goal ToModel()
    {
        return new Goal
        {
            goal_amount = GoalAmount,
            Deadline = Deadline,
            current_amount = CurrentAmount,
            user_id = UserId
        };
    }
}
