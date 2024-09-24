using Dapper;
using ExpenseTrackerGrupo2.Persistence.Database;
using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory) { }

    public async Task<IList<Expense>> GetExpenseByCategory(string category)
    {
        using var connection = await _dbConnectionFactory.CreateConnection();
        var query = "SELECT * FROM expenses WHERE category = @Category";
        var expenses = await connection.QueryAsync<Expense>(query, new { Category = category });
        return expenses.ToList();
    }

    public async Task<int> GetExpenseByDate(DateTime startDate, DateTime endDate)
    {
        using var connection = await _dbConnectionFactory.CreateConnection();
        var query = "SELECT COUNT(*) FROM expenses WHERE expense_date >= @StartDate AND expense_date <= @EndDate";
        var count = await connection.ExecuteScalarAsync<int>(query, new { StartDate = startDate, EndDate = endDate });
        return count;
    }
}
