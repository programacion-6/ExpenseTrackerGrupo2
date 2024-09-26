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

        Console.WriteLine($"Received request: {request.Amount}, {request.Description}, {request.Category}, {request.Date}");

        try
        {
            Console.WriteLine($"Making Post"); 
            var result = await _expenseService.CreateExpense(request);

            Console.WriteLine($"Inserting Expense: {result}"); 
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
        [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExpense(Guid id, [FromBody] ExpenseUpdateRequest request)
    {
        if (id == Guid.Empty || !ModelState.IsValid)
        {
            return BadRequest("Invalid ID format or request data.");
        }

        try
        {
            var updatedExpense = await _expenseService.UpdateExpense(request);

            if (updatedExpense == null)
            {
                return NotFound($"Expense with ID {id} not found.");
            }

            return Ok(updatedExpense);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
