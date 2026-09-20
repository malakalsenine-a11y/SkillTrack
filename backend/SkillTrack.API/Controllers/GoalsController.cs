using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/goals")]
[Authorize]
public class GoalsController : BaseApiController
{
    private readonly IGoalService _goalService;

    public GoalsController(IGoalService goalService)
    {
        _goalService = goalService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<GoalDto>>> GetMyGoals(CancellationToken cancellationToken)
    {
        var goals = await _goalService.GetByUserIdAsync(GetCurrentUserId(), cancellationToken);
        return Ok(goals);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GoalDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var goal = await _goalService.GetByIdAsync(id, GetCurrentUserId(), cancellationToken);
        return goal is null ? NotFound() : Ok(goal);
    }

    [HttpPost]
    public async Task<ActionResult<GoalDto>> Create(CreateGoalRequestDto request, CancellationToken cancellationToken)
    {
        var goal = await _goalService.CreateAsync(GetCurrentUserId(), request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = goal.Id }, goal);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<GoalDto>> Update(Guid id, UpdateGoalRequestDto request, CancellationToken cancellationToken)
    {
        var goal = await _goalService.UpdateAsync(id, GetCurrentUserId(), request, cancellationToken);
        return Ok(goal);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _goalService.DeleteAsync(id, GetCurrentUserId(), cancellationToken);
        return NoContent();
    }
}
