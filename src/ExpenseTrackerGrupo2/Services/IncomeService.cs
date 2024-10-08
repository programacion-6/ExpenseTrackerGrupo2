using ExpenseTrackerGrupo2.Business.Services.Interfaces;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Incomes;
using ExpenseTrackerGrupo2.DataAccess.Concretes;
using ExpenseTrackerGrupo2.DataAccess.Entities;

public class IncomeService : IIncomeServices
{
    private readonly IIncomeRepository _incomeRepository;

    public IncomeService(IIncomeRepository incomeRepository)
    {
        this._incomeRepository = incomeRepository;
    }

    public async Task<int> CreateIncome(IncomeCreateRequest income)
    {
        try
        {
            var incomeModel = income.ToModel();
            var productResponse = await _incomeRepository.Create(incomeModel);
            return productResponse;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while creating the income: {ex.Message}");
        }
    }

    public async Task<bool> DeleteIncome(Guid incomeId)
    {
        try
        {
            var result = await _incomeRepository.Delete(incomeId);
            return result;
        }
        catch (KeyNotFoundException ex)
        {
            throw new KeyNotFoundException($"Income with ID {incomeId} not found. {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while deleting the income: {ex.Message}");
        }
    }

    public async Task<IList<Income>> GetAllIncomes()
    {
        try
        {
            var incomes = await _incomeRepository.GetAll();
            return incomes;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving all incomes: {ex.Message}");
        }
    }

    public async Task<Income> GetIncomeById(Guid incomeId)
    {
        try
        {
            var income = await _incomeRepository.GetById(incomeId);

            if (income == null)
            {
                throw new KeyNotFoundException($"Income with ID {incomeId} not found.");
            }

            return income;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the income: {ex.Message}");
        }
    }

    public async Task<int> UpdateIncome(IncomeUpdateRequest income, Guid id)
    {
        try
        {
            var incomeModel = income.ToModel();
            var result = await _incomeRepository.Update(incomeModel, id);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while updating the income: {ex.Message}");
        }
    }
}
