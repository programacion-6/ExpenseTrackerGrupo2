using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public interface IGoalRepository : IBaseRepository<Goal>
{
    Task<IList<Expense>> NotifyGoal(int actualGoal);
}
