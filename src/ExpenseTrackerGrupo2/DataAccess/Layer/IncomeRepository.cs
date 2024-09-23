using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.Data;
using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Layer;
public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
{
    public IncomeRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory) {}

    public Task<IList<Income>> GetIncomeBySource(string source)
    {
        throw new NotImplementedException();
    } 
}
