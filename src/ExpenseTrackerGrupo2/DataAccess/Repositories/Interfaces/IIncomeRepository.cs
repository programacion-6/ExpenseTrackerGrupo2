using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public interface IIncomeRepository : IBaseRepository<Income>
{
    Task<IList<Income>> GetIncomeBySource(string source);
}
