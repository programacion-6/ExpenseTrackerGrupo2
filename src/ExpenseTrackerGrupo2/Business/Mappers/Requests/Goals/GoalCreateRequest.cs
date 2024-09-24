using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Goals;

public record GoalCreateRequest
(
    decimal GoalAmount,
    DateTime Deadline,
    decimal CurrentAmount
)
{ 
    public Goal ToModel()
    {
        return new Goal
        {
            GoalAmount = GoalAmount,
            Deadline = Deadline,
            CurrentAmount = CurrentAmount
        };
    }
}
