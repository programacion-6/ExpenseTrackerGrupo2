using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerGrupo2.Business.Services.Interfaces;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Incomes;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Goals;

namespace ExpenseTrackerGrupo2.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;
        private readonly IGoalService _goalService; 

        public IncomeController(IIncomeService incomeService, IGoalService goalService)
        {
            _incomeService = incomeService;
            _goalService = goalService;
        }

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

        [HttpGet]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeService.GetAllIncomes();
            if (incomes == null || !incomes.Any())
            {
                return Ok(new { Message = "No incomes found." });
            }

            return Ok(incomes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncome([FromBody] IncomeCreateRequest request)
        {
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

                string notificationMessage = string.Empty;

                var goal = await _goalService.GetGoalByUserId(request.User);
                if (goal != null)
                {
                    goal.current_amount += request.Amount;
                    var goalUpdateRequest = new GoalUpdateRequest
                    (

                        goal.goal_amount,
                        goal.Deadline,
                        goal.current_amount,
                        goal.user_id
                    );

                    await _goalService.UpdateGoal(goalUpdateRequest, goal.goal_id);

                    var progress = (goal.current_amount/ goal.goal_amount) * 100;
                    if (progress >= 50 && progress < 75)
                    {
                        notificationMessage = "You've reached 50% of your savings goal!";
                    }
                    else if (progress >= 75 && progress < 100)
                    {
                        notificationMessage = "You've reached 75% of your savings goal!";
                    }
                    else if (progress >= 100)
                    {
                        notificationMessage = "You've reached 100% of your savings goal!";
                    }
                }
                var createdIncome = await _incomeService.CreateIncome(request);
                return CreatedAtAction(nameof(GetIncomeById), new { id = createdIncome}, new 
                {
                    Income = createdIncome,
                    Notification = notificationMessage
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the income: {ex.Message}");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncome(Guid id, [FromBody] IncomeUpdateRequest request)
        {
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
                int? updatedIncome = await _incomeService.UpdateIncome(request, id);
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
