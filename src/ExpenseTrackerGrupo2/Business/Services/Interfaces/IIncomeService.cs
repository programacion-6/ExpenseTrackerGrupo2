using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Incomes;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;

namespace ExpenseTrackerGrupo2.Business.Services.Interfaces;

public interface IIncomeServices
{
    Task<IList<IncomeResponse>> GetAllIncomes();
    Task<IncomeResponse> GetIncomeById(Guid incomeId);
    Task<int> CreateIncome(IncomeCreateRequest income);
    Task<int> UpdateIncome(IncomeUpdateRequest income, Guid id);
    Task<bool> DeleteIncome(Guid incomeId);
}
