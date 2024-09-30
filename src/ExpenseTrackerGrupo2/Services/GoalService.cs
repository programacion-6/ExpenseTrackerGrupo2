using ExpenseTrackerGrupo2.Business.Services.Interfaces;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Goals;
using ExpenseTrackerGrupo2.DataAccess.Concretes;
using ExpenseTrackerGrupo2.DataAccess.Entities;

public class GoalService : IGoalService
{
    private readonly IGoalRepository _goalRepository;

    public GoalService(IGoalRepository goalRepository)
    {
        this._goalRepository = goalRepository;
    }

    public async Task<int> CreateGoal(GoalCreateRequest goal)
    {
        try
        {
            var goalModel = goal.ToModel();
            var response = await _goalRepository.Create(goalModel);
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to create the goal: {ex.Message}");
        }
    }

    public async Task<bool> DeleteGoal(Guid goalId)
    {
        try
        {
            var response = await _goalRepository.Delete(goalId);
            return response;
        }
        catch (KeyNotFoundException ex)
        {
            throw new KeyNotFoundException($"Goal with ID {goalId} not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while deleting the goal: {ex.Message}");
        }
    }

    public async Task<IList<Goal>> GetAllGoals()
    {
        try
        {
            var goals = await _goalRepository.GetAll();
            return goals;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving all goals: {ex.Message}");
        }
    }

    public async Task<Goal> GetGoalById(Guid goalId)
    {
        try
        {
            var goal = await _goalRepository.GetById(goalId);
            if (goal == null)
            {
                throw new KeyNotFoundException($"Goal with ID {goalId} not found.");
            }
            return goal;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the goal: {ex.Message}");
        }
    }

    public async Task<int> UpdateGoal(GoalUpdateRequest goal)
    {
        try
        {
            var goalModel = goal.ToModel();
            var response = await _goalRepository.Update(goalModel);
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while updating the goal: {ex.Message}");
        }
    }

    public async Task<Goal>GetGoalByUserId(Guid userId)
    {
        try
        {
            var goals = await _goalRepository.GetGoalByUserId(userId);
            return goals;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving all goals: {ex.Message}");
        }
    }
}