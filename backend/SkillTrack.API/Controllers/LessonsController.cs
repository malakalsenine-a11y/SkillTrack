using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/lessons")]
public class LessonsController : BaseApiController
{
    private readonly ILessonService _lessonService;

    public LessonsController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LessonDetailDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var lesson = await _lessonService.GetByIdAsync(id, cancellationToken);
        return lesson is null ? NotFound() : Ok(lesson);
    }

    [HttpGet("module/{moduleId:guid}")]
    public async Task<ActionResult<IReadOnlyList<LessonDto>>> GetByModuleId(Guid moduleId, CancellationToken cancellationToken)
    {
        var lessons = await _lessonService.GetByModuleIdAsync(moduleId, cancellationToken);
        return Ok(lessons);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<LessonDto>> Create(CreateLessonRequestDto request, CancellationToken cancellationToken)
    {
        var lesson = await _lessonService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = lesson.Id }, lesson);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<LessonDto>> Update(Guid id, UpdateLessonRequestDto request, CancellationToken cancellationToken)
    {
        var lesson = await _lessonService.UpdateAsync(id, request, cancellationToken);
        return Ok(lesson);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _lessonService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    /// <summary>Explicit "mark complete" action (spec section 4.1) - opening a
    /// lesson is not the same as completing it.</summary>
    [HttpPost("{id:guid}/complete")]
    [Authorize]
    public async Task<IActionResult> MarkComplete(Guid id, CancellationToken cancellationToken)
    {
        await _lessonService.MarkCompleteAsync(GetCurrentUserId(), id, cancellationToken);
        return NoContent();
    }
}
