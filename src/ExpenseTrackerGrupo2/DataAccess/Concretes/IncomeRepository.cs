using Dapper;
using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.Data;
using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Concretes;
public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
{
    public IncomeRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory) { }

    public async Task<IList<Income>> GetIncomeBySource(string source)
    {
        using var connection = await _dbConnectionFactory.CreateConnection();
        var query = "SELECT * FROM Incomes WHERE Source = @Source";
        var incomes = await connection.QueryAsync<Income>(query, new { Source = source });
        return incomes.ToList();
    }
}
