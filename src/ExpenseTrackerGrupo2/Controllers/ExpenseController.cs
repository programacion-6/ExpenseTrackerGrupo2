using ExpenseTrackerGrupo2.Business.Services.Interfaces;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Expenses;

using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerGrupo2.Controllers;

[ApiController]
[Route("api/expenses")]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseService _expenseService;

    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateExpense([FromBody] ExpenseCreateRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = await _expenseService.CreateExpense(request);

            if (result > 0)
            {
                return CreatedAtAction(nameof(GetExpenseById), request);
            }

            return StatusCode(500, "An error occurred while creating the expense.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExpenseById(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID format.");
            }

            var expenses = await _expenseService.GetExpenseById(id);
            if (expenses == null)
            {
                return NotFound($"Expense with ID {id} not found.");
            }
            return Ok(expenses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Invalid ID format.");
        }

        try
        {
            var deleted = await _expenseService.DeleteExpense(id);

            if (!deleted)
            {
                return NotFound($"Expense with ID {id} not found.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

     [HttpGet]
    public async Task<IActionResult> GetExpenses()
    {
        try
        {
            var expenses = await _expenseService.GetAllExpenses();

            if (expenses == null || !expenses.Any())
            {
                return NotFound("No expenses found matching the criteria.");
            }

            return Ok(expenses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}