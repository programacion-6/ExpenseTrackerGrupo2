using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Goals;
using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Interfaces;

public interface IGoalService
{
    Task<IList<Goal>> GetAllGoals();
    Task<Goal> GetGoalById(Guid goalId);
    Task<int> CreateGoal(GoalCreateRequest goal);
    Task<int> UpdateGoal(GoalUpdateRequest goal, Guid id);
    Task<bool> DeleteGoal(Guid goalId);
    Task<Goal> GetGoalByUserId (Guid userId);
}