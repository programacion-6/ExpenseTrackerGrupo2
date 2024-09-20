using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Incomes;
using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Interfaces;

public interface IIncomeServices
{
    // TODO: Update according VOs
    Task<IList<Income>> GetAllIncomes();
    Task<Income> GetIncomeById(Guid incomeId);
    Task<int> CreateIncome(IncomeCreateRequest income);
    Task<int> UpdateIncome(IncomeUpdateRequest income);
    Task<bool> DeleteIncome(Guid incomeId);
}
