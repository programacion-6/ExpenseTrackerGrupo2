using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ExpenseTrackerGrupo2.Business.Services.Interfaces;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Incomes;

namespace ExpenseTrackerGrupo2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeServices _incomeService;

        public IncomeController(IIncomeServices incomeService)
        {
            _incomeService = incomeService;
        }

        // GET: /api/income/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncomeById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID format.");
            }

            var income = await _incomeService.GetIncomeById(id);
            if (income == null)
            {
                return NotFound($"Income with ID {id} not found.");
            }

            return Ok(income);
        }

        // GET: /api/income
        [HttpGet]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeService.GetAllIncomes();
            if (incomes == null || incomes.Count == 0)
            {
                return Ok(new { Message = "No incomes found." });
            }

            return Ok(incomes);
        }

        // POST: /api/income
        [HttpPost]
        public async Task<IActionResult> CreateIncome([FromBody] IncomeCreateRequest request)
        {
            // Validations
            if (request == null)
            {
                return BadRequest("Request body cannot be null.");
            }

            if (request.Amount <= 0)
            {
                return BadRequest("Amount must be a positive number.");
            }

            if (string.IsNullOrWhiteSpace(request.Source))
            {
                return BadRequest("Source cannot be empty.");
            }

            try
            {
                var createdIncome = await _incomeService.CreateIncome(request);
                return CreatedAtAction(nameof(GetIncomeById), new { id = createdIncome }, createdIncome);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the income: {ex.Message}");
            }
        }

        // PUT: /api/income/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncome(Guid id, [FromBody] IncomeUpdateRequest request)
        {
            // Validations
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID format.");
            }

            if (request == null)
            {
                return BadRequest("Request body cannot be null.");
            }

            if (request.Amount <= 0)
            {
                return BadRequest("Amount must be a positive number.");
            }

            try
            {
                var updatedIncome = await _incomeService.UpdateIncome(request);
                if (updatedIncome == null)
                {
                    return NotFound($"Income with ID {id} not found.");
                }

                return Ok(updatedIncome);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the income: {ex.Message}");
            }
        }

        // DELETE: /api/income/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID format.");
            }

            try
            {
                var isDeleted = await _incomeService.DeleteIncome(id);
                if (!isDeleted)
                {
                    return NotFound($"Income with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the income: {ex.Message}");
            }
        }
    }
}