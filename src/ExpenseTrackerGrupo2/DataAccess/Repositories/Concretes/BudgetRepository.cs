using Dapper;
using ExpenseTrackerGrupo2.Persistence.Database;
using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public class BudgetRepository : BaseRepository<Budget>, IBudgetRepository
{
    public BudgetRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory) { }

       public async Task<bool> SetBudget(Budget budget)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            var query = "INSERT INTO budget (budget_id, user_id, month, year, amount) VALUES (@BudgetId, @UserId, @Month, @Year, @Amount)";
            var rowsAffected = await connection.ExecuteAsync(query, budget);
            return rowsAffected > 0;
        }

        public async Task<Budget> GetBudgetByUserIdAndMonth(Guid userId, int month, int year)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            var query = "SELECT * FROM budget WHERE user_id = @UserId AND month = @Month AND year = @Year";
            var budget = await connection.QuerySingleOrDefaultAsync<Budget>(query, new { UserId = userId, Month = month, Year = year });
            return budget;
        }
}
