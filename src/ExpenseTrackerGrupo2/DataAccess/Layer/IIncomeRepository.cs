using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;
namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Layer;

public interface IIncomeRepository : IBaseRepository<Income>
{
    Task<IList<Income>> GetIncomeBySource(string source);
}
