using Dapper;
using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.Data;
using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Layer;

public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory) { }

    public async Task<IList<Expense>> GetExpenseByCategory(string category)
    {
        using var connection = await _dbConnectionFactory.CreateConnection();
        var query = "SELECT * FROM Expenses WHERE Category = @Category";
        var expenses = await connection.QueryAsync<Expense>(query, new { Category = category });
        return expenses.ToList();
    }

    public async Task<int> GetExpenseByDate(DateTime startDate, DateTime endDate)
    {
        using var connection = await _dbConnectionFactory.CreateConnection();
        var query = "SELECT COUNT(*) FROM Expenses WHERE Date >= @StartDate AND Date <= @EndDate";
        var count = await connection.ExecuteScalarAsync<int>(query, new { StartDate = startDate, EndDate = endDate });
        return count;
    }
}
