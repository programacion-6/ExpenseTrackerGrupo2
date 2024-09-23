using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.Data;
using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Layer;

public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory) {}

    public Task<IList<Expense>> GetExpenseByCategory(string category)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetExpenseByDate(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }
}
