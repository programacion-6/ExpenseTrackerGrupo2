using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Goals;

public record GoalCreateRequest
(
    decimal GoalAmount,
    DateTime Deadline,
    Guid userId
)
{ 
    public Goal ToModel()
    {
        return new Goal
        {
            goal_amount = GoalAmount,
            Deadline = Deadline,
            current_amount = 0,
            user_id = userId
        };
    }
}
