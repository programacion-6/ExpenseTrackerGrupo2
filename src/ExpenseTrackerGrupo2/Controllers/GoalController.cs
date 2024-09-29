using ExpenseTrackerGrupo2.Business.Services.Interfaces;
using ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Goals;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerGrupo2.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        // GET: /api/goal/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGoalById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID format.");
            }

            var goal = await _goalService.GetGoalById(id);
            if (goal == null)
            {
                return NotFound($"Goal with ID {id} not found.");
            }

            return Ok(goal);
        }

        // GET: /api/goal
        [HttpGet]
        public async Task<IActionResult> GetAllGoals()
        {
            var goals = await _goalService.GetAllGoals();
            if (goals == null || goals.Count == 0)
            {
                return Ok(new { Message = "No goals found." });
            }

            return Ok(goals);
        }

        // POST: /api/goal
        [HttpPost]
        public async Task<IActionResult> CreateGoal([FromBody] GoalCreateRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body cannot be null.");
            }

            if (request.GoalAmount <= 0)
            {
                return BadRequest("Target amount must be a positive number.");
            }

            try
            {
                var createdGoal = await _goalService.CreateGoal(request);
                return CreatedAtAction(nameof(GetGoalById), new { id = createdGoal }, createdGoal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the goal: {ex.Message}");
            }
        }

        // PUT: /api/goal/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoal(Guid id, [FromBody] GoalUpdateRequest request)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID format.");
            }

            if (request == null)
            {
                return BadRequest("Request body cannot be null.");
            }

            try
            {
                var updatedGoal = await _goalService.UpdateGoal(request);
                if (updatedGoal == 0)
                {
                    return NotFound($"Goal with ID {id} not found.");
                }

                return Ok(updatedGoal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the goal: {ex.Message}");
            }
        }

        // DELETE: /api/goal/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID format.");
            }

            try
            {
                var isDeleted = await _goalService.DeleteGoal(id);
                if (!isDeleted)
                {
                    return NotFound($"Goal with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the goal: {ex.Message}");
            }
        }
    }
}
