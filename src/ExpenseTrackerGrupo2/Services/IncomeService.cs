using ExpenseTrackerGrupo2.Business.Services.Interfaces;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Incomes;
using ExpenseTrackerGrupo2.DataAccess.Concretes;
using ExpenseTrackerGrupo2.DataAccess.Entities;

public class IncomeService : IIncomeServices
{
    private readonly IncomeRepository _incomeRepository;

    public IncomeService(IncomeRepository incomeRepository)
    {
        this._incomeRepository = incomeRepository;
    }

    public async Task<int> CreateIncome(IncomeCreateRequest income)
    {
        var incomeModel = income.ToModel();
        var productResponse = await _incomeRepository.Create(incomeModel);
        return productResponse;
    }

    public async Task<bool> DeleteIncome(Guid incomeId)
    {
        var result = await _incomeRepository.Delete(incomeId);
        return result;
    }

    public async Task<IList<Income>> GetAllIncomes()
    {
        var incomes = await _incomeRepository.GetAll();
        return incomes;
    }

    public async Task<Income> GetIncomeById(Guid incomeId)
    {
        var income = await _incomeRepository.GetById(incomeId);
        if (income == null)
        {
            throw new KeyNotFoundException($"Income with ID {incomeId} not found.");
        }
        return income;
    }

    public async Task<int> UpdateIncome(IncomeUpdateRequest income)
    {
        var incomeModel = income.ToModel();
        var result = await _incomeRepository.Update(incomeModel);
        return result;
    }
}
