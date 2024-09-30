using ExpenseTrackerGrupo2.Business.Services.Interfaces;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Expenses;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;
using ExpenseTrackerGrupo2.DataAccess.Concretes;

namespace ExpenseTrackerGrupo2.Business.Services.Concretes;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseService(IExpenseRepository expenseRepository)
    {
        this._expenseRepository = expenseRepository;
    }

    public async Task<int> CreateExpense(ExpenseCreateRequest expense)
    {
        try
        {
            var expenseModel = expense.ToModel();
            var response = await _expenseRepository.Create(expenseModel);
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to create the expense: {ex.Message}");
        }
    }

    public async Task<bool> DeleteExpense(Guid expenseId)
    {
        try
        {
            var response = await _expenseRepository.Delete(expenseId);
            return response;
        }
        catch (KeyNotFoundException ex)
        {
            throw new KeyNotFoundException($"Expense with ID {expenseId} not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while deleting the expense: {ex.Message}");
        }
    }

    public async Task<IList<ExpenseResponse>> GetAllExpenses()
    {
        try
        {
            var expenses = await _expenseRepository.GetAll();
            var expenseResponses = expenses.Select(ExpenseResponse.FromDomain).ToList();
            
            return expenseResponses;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving all expenses: {ex.Message}");
        }
    }

    public async Task<ExpenseResponse> GetExpenseById(Guid expenseId)
    {
        try
        {
            var expense = await _expenseRepository.GetById(expenseId);

            if (expense == null)
            {
                throw new KeyNotFoundException($"Expense with ID {expenseId} not found.");
            }

            return ExpenseResponse.FromDomain(expense);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the expense: {ex.Message}");
        }
    }

    public async Task<IList<ExpenseResponse>> GetExpenses(DateTime? startDate, DateTime? endDate, string? category)
    {
        var expenses = await _expenseRepository.GetAll();

        if (startDate.HasValue)
        {
            expenses = expenses.Where(e => e.expense_date >= startDate.Value).ToList();
        }

        if (endDate.HasValue)
        {
            expenses = expenses.Where(e => e.expense_date <= endDate.Value).ToList();
        }

        if (!string.IsNullOrEmpty(category))
        {
            expenses = expenses.Where(e => e.Category == category).ToList();
        }

        var expenseResponses = expenses.Select(ExpenseResponse.FromDomain).ToList();

        return expenseResponses;
    }

    public async Task<int> UpdateExpense(ExpenseUpdateRequest expense, Guid id)
    {
        try
        {
            var existingExpense = await _expenseRepository.GetById(id);

            if (existingExpense == null)
            {
                throw new KeyNotFoundException($"Expense with ID {id} not found.");
            }
            else
            {
                var expenseModel = expense.ToModel();
                var response = await _expenseRepository.Update(expenseModel, id);
                return response;
            }
         }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while updating the expense: {ex.Message}");
        }
    }
        public async Task<string> GetHighestSpendingCategory()
    {
        try
    {
        var expenses = await _expenseRepository.GetAll();

        var topSpendingCategories = expenses
            .GroupBy(e => e.Category)
            .Select(g => new
            {
                Category = g.Key,
                Total = g.Sum(e => e.Amount)
            })
            .OrderByDescending(g => g.Total)
            .Take(2)
            .ToList();

        if (topSpendingCategories.Any())
        {
            var result = string.Join("\n", topSpendingCategories.Select(c => $"Category: {c.Category} - Total Spending: {c.Total}"));
            return result;
        }
        else
        {
            return "No expenses found.";
        }
    }
    catch (Exception ex)
    {
        throw new Exception($"An error occurred while retrieving the top two spending categories: {ex.Message}");
    }
    }
}
