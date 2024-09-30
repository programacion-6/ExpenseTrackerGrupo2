using ExpenseTrackerGrupo2.Business.Services.Interfaces;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Budgets;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;
using ExpenseTrackerGrupo2.DataAccess.Concretes;
using ExpenseTrackerGrupo2.DataAccess.Entities;

public class BudgetService : IBudgetService
{
    private readonly IBudgetRepository _budgetRepository;

    public BudgetService(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public async Task<BudgetResponse> GetBudgetById(Guid id)
    {
        try
        {
            var budget = await _budgetRepository.GetById(id);
            
            if (budget == null)
            {
                throw new KeyNotFoundException("Budget not found.");
            }

            return BudgetResponse.FromDomain(budget);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the budget: {ex.Message}");
        }
    }

    public async Task<IList<BudgetResponse>> GetAllBudgets()
    {
        try
        {
            var budgets = await _budgetRepository.GetAll();
            var budgetResponses = budgets.Select(BudgetResponse.FromDomain).ToList();
            
            return budgetResponses;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving all budgets: {ex.Message}");
        }
    }

    public async Task<int> CreateBudget(BudgetCreateRequest request)
    {
        try
        {
            var budgetModel = request.ToModel();
            var createdBudget = await _budgetRepository.Create(budgetModel);
            return createdBudget;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while creating the budget: {ex.Message}");
        }
    }

    public async Task<int> UpdateBudget(BudgetUpdateRequest request, Guid id)
    {
        try
        {
            var existingBudget = await _budgetRepository.GetById(id);

            if (existingBudget == null)
            {
                throw new KeyNotFoundException($"Expense with ID {id} not found.");
            }
            else
            {
                var expenseModel = request.ToModel();
                var response = await _budgetRepository.Update(expenseModel, id);
                return response;
            }
         }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while updating the expense: {ex.Message}");
        }
    }

    public async Task<bool> DeleteBudget(Guid id)
    {
        try
        {
            var response = await _budgetRepository.Delete(id);
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while deleting the budget: {ex.Message}");
        }
    }
}
