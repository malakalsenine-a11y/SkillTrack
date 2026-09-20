using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/learning-paths")]
public class LearningPathsController : BaseApiController
{
    private readonly ILearningPathService _learningPathService;

    public LearningPathsController(ILearningPathService learningPathService)
    {
        _learningPathService = learningPathService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<LearningPathDto>>> Search(
        [FromQuery] string? searchTerm,
        [FromQuery] Guid? skillId,
        [FromQuery] DifficultyLevel? difficulty,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var result = await _learningPathService.SearchAsync(searchTerm, skillId, difficulty, page, pageSize, cancellationToken);
        return Ok(result);
    }

    [HttpGet("popular")]
    public async Task<ActionResult<IReadOnlyList<LearningPathDto>>> GetMostPopular([FromQuery] int count = 5, CancellationToken cancellationToken = default)
    {
        var paths = await _learningPathService.GetMostPopularAsync(count, cancellationToken);
        return Ok(paths);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LearningPathDetailDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var path = await _learningPathService.GetByIdAsync(id, cancellationToken);
        return path is null ? NotFound() : Ok(path);
    }

    [HttpPost("{id:guid}/enroll")]
    [Authorize]
    public async Task<IActionResult> Enroll(Guid id, CancellationToken cancellationToken)
    {
        await _learningPathService.EnrollUserAsync(GetCurrentUserId(), id, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<LearningPathDto>> Create(CreateLearningPathRequestDto request, CancellationToken cancellationToken)
    {
        var path = await _learningPathService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = path.Id }, path);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<LearningPathDto>> Update(Guid id, UpdateLearningPathRequestDto request, CancellationToken cancellationToken)
    {
        var path = await _learningPathService.UpdateAsync(id, request, cancellationToken);
        return Ok(path);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _learningPathService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
