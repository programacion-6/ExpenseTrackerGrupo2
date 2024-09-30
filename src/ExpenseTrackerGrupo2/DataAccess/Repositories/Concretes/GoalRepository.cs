using Dapper;
using ExpenseTrackerGrupo2.Persistence.Database;
using ExpenseTrackerGrupo2.DataAccess.Entities;
using ExpenseTrackerGrupo2.Utils;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public class GoalRepository : BaseRepository<Goal>, IGoalRepository
{
    public GoalRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory){}

   public async Task<Goal> GetGoalByUserId(Guid userId)
    {   
        var tableName = StringUtils.ToSnakeCase(typeof(Goal).Name);
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        
        var result = await connection.QuerySingleOrDefaultAsync<Goal>(
            $"SELECT * FROM {tableName} WHERE user_id = @UserId", 
            new { UserId = userId }
        );
        
        return result;
    }
}