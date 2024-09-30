using ExpenseTrackerGrupo2.Business.Services.Interfaces;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Expenses;

using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerGrupo2.Controllers;

[ApiController]
[Route("api/v1/expenses")]
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
        if (request == null)
        {
            return BadRequest("Request body cannot be null.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdExpense = await _expenseService.CreateExpense(request);

            if (createdExpense > 0)
            {
                return CreatedAtAction(nameof(GetExpenseById), new { id = createdExpense }, createdExpense);
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

            var expense = await _expenseService.GetExpenseById(id);
            if (expense == null)
            {
                return NotFound($"Expense with ID {id} not found.");
            }
            return Ok(expense);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetExpenses(
                                                 [FromQuery] DateTime? startDate,
                                                 [FromQuery] DateTime? endDate,
                                                 [FromQuery] string? category
                                                 )
    {
        try
        {
            var expenses = await _expenseService.GetExpenses(startDate, endDate, category);

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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExpense(Guid id, [FromBody] ExpenseUpdateRequest request)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Invalid ID format.");
        }

        if (request == null)
        {
            return BadRequest("Request body cannot be null.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updatedExpense = await _expenseService.UpdateExpense(request, id);
            return Ok(updatedExpense);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
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
}