using Dapper;
using ExpenseTrackerGrupo2.Persistence.Database;
using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public class GoalRepository : BaseRepository<Goal>, IGoalRepository
{
    public GoalRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory){}

    public Task<IList<Expense>> NotifyGoal(int actualGoal)
    {
        throw new NotImplementedException();
    }
}