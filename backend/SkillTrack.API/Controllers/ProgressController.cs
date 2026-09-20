using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/progress")]
[Authorize]
public class ProgressController : BaseApiController
{
    private readonly IProgressService _progressService;

    public ProgressController(IProgressService progressService)
    {
        _progressService = progressService;
    }

    /// <summary>The full "meaningful learning indicators" breakdown (spec section 7) -
    /// deliberately not just a single percentage.</summary>
    [HttpGet]
    public async Task<ActionResult<OverallProgressDto>> GetOverallProgress(CancellationToken cancellationToken)
    {
        var progress = await _progressService.GetOverallProgressAsync(GetCurrentUserId(), cancellationToken);
        return Ok(progress);
    }

    [HttpGet("learning-paths/{learningPathId:guid}")]
    public async Task<ActionResult<LearningPathProgressDto>> GetLearningPathProgress(Guid learningPathId, CancellationToken cancellationToken)
    {
        var progress = await _progressService.GetLearningPathProgressAsync(GetCurrentUserId(), learningPathId, cancellationToken);
        return Ok(progress);
    }

    [HttpGet("skills")]
    public async Task<ActionResult<IReadOnlyList<SkillProgressDto>>> GetSkillProgress(CancellationToken cancellationToken)
    {
        var progress = await _progressService.GetSkillProgressAsync(GetCurrentUserId(), cancellationToken);
        return Ok(progress);
    }
}
