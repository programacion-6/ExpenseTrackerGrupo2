using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;
namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Layer;

public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public IncomeRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IList<Income>> GetIncomeBySourceAsync(string source)
    {
        using (var connection = await _connectionFactory.CreateConnection())
        {
            var incomes = await connection.QueryAsync<Income>(
                "SELECT * FROM Incomes WHERE Source = @Source", new { Source = source });
            return incomes.ToList();
        }
    }
}