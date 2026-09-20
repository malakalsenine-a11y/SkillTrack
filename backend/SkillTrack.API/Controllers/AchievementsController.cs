using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/achievements")]
public class AchievementsController : BaseApiController
{
    private readonly IAchievementService _achievementService;

    public AchievementsController(IAchievementService achievementService)
    {
        _achievementService = achievementService;
    }

    /// <summary>All achievement definitions - visible to everyone so learners know
    /// what's achievable, not just what they've earned.</summary>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AchievementDto>>> GetAll(CancellationToken cancellationToken)
    {
        var achievements = await _achievementService.GetAllAsync(cancellationToken);
        return Ok(achievements);
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<IReadOnlyList<UserAchievementDto>>> GetMyAchievements(CancellationToken cancellationToken)
    {
        var achievements = await _achievementService.GetByUserIdAsync(GetCurrentUserId(), cancellationToken);
        return Ok(achievements);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<AchievementDto>> Create(CreateAchievementRequestDto request, CancellationToken cancellationToken)
    {
        var achievement = await _achievementService.CreateAsync(request, cancellationToken);
        return Ok(achievement);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<AchievementDto>> Update(Guid id, UpdateAchievementRequestDto request, CancellationToken cancellationToken)
    {
        var achievement = await _achievementService.UpdateAsync(id, request, cancellationToken);
        return Ok(achievement);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _achievementService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
