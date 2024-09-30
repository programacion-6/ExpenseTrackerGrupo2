using ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;
using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public interface IIncomeRepository : IBaseRepository<Income>
{
    Task<IList<IncomeResponse>> GetIncomeBySource(string source);
}
