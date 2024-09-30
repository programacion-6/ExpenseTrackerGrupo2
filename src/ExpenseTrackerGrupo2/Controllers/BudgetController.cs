using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerGrupo2.Business.Services.Interfaces;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Budgets;

namespace ExpenseTrackerGrupo2.API.Controllers
{
    [ApiController]
    [Route("api/v1/budget/[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudgetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID format.");
            }

            var budget = await _budgetService.GetBudgetById(id);
            if (budget == null)
            {
                return NotFound($"Budget with ID {id} not found.");
            }

            return Ok(budget);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBudgets()
        {
            var budgets = await _budgetService.GetAllBudgets();
            if (budgets == null || !budgets.Any())
            {
                return Ok(new { Message = "No budgets found." });
            }

            return Ok(budgets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBudget([FromBody] BudgetCreateRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body cannot be null.");
            }

            if (request.BudgetAmount <= 0)
            {
                return BadRequest("Budget amount must be a positive number.");
            }

            try
            {
                var createdBudget = await _budgetService.CreateBudget(request);
                return CreatedAtAction(nameof(GetBudgetById), new { id = createdBudget.budget_id }, createdBudget);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the budget: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBudget(Guid id, [FromBody] BudgetUpdateRequest request)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID format.");
            }

            if (request == null)
            {
                return BadRequest("Request body cannot be null.");
            }

            if (request.BudgetAmount <= 0)
            {
                return BadRequest("Budget amount must be a positive number.");
            }

            try
            {
                var updatedBudget = await _budgetService.UpdateBudget(request, id);
                if (updatedBudget == null)
                {
                    return NotFound($"Budget with ID {id} not found.");
                }

                return Ok(updatedBudget);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the budget: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID format.");
            }

            try
            {
                var isDeleted = await _budgetService.DeleteBudget(id);
                if (!isDeleted)
                {
                    return NotFound($"Budget with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the budget: {ex.Message}");
            }
        }
    }
}
