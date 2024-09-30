using Dapper;
using ExpenseTrackerGrupo2.Persistence.Database;
using ExpenseTrackerGrupo2.DataAccess.Entities;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
{
    public IncomeRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory) { }

    public async Task<IList<IncomeResponse>> GetIncomeBySource(string source)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        var query = "SELECT * FROM incomes WHERE source = @Source";
        var incomes = await connection.QueryAsync<Income>(query, new { Source = source });
        var incomeResponses = incomes.Select(IncomeResponse.FromDomain).ToList();

        return incomeResponses;
    }
}
