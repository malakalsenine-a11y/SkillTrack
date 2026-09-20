using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/assignments")]
public class AssignmentsController : BaseApiController
{
    private readonly IAssignmentService _assignmentService;

    public AssignmentsController(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AssignmentDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var assignment = await _assignmentService.GetByIdAsync(id, cancellationToken);
        return assignment is null ? NotFound() : Ok(assignment);
    }

    [HttpGet("module/{moduleId:guid}")]
    public async Task<ActionResult<IReadOnlyList<AssignmentDto>>> GetByModuleId(Guid moduleId, CancellationToken cancellationToken)
    {
        var assignments = await _assignmentService.GetByModuleIdAsync(moduleId, cancellationToken);
        return Ok(assignments);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<AssignmentDto>> Create(CreateAssignmentRequestDto request, CancellationToken cancellationToken)
    {
        var assignment = await _assignmentService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = assignment.Id }, assignment);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<AssignmentDto>> Update(Guid id, UpdateAssignmentRequestDto request, CancellationToken cancellationToken)
    {
        var assignment = await _assignmentService.UpdateAsync(id, request, cancellationToken);
        return Ok(assignment);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _assignmentService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPost("{id:guid}/submissions")]
    [Authorize]
    public async Task<ActionResult<AssignmentSubmissionDto>> Submit(Guid id, SubmitAssignmentRequestDto request, CancellationToken cancellationToken)
    {
        request.AssignmentId = id;
        var submission = await _assignmentService.SubmitAsync(GetCurrentUserId(), request, cancellationToken);
        return Ok(submission);
    }

    [HttpGet("{id:guid}/submissions/me")]
    [Authorize]
    public async Task<ActionResult<AssignmentSubmissionDto>> GetMySubmission(Guid id, CancellationToken cancellationToken)
    {
        var submission = await _assignmentService.GetSubmissionByUserAsync(GetCurrentUserId(), id, cancellationToken);
        return submission is null ? NotFound() : Ok(submission);
    }

    /// <summary>Admin review queue (spec section 10), optionally filtered by status, paged.</summary>
    [HttpGet("submissions")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<PagedResult<AssignmentSubmissionDto>>> GetForReview(
        [FromQuery] SubmissionStatus? status,
        [FromQuery] Guid? assignmentId,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var result = await _assignmentService.GetForReviewAsync(status, assignmentId, page, pageSize, cancellationToken);
        return Ok(result);
    }

    [HttpPut("submissions/{submissionId:guid}/grade")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<AssignmentSubmissionDto>> GradeSubmission(Guid submissionId, GradeAssignmentRequestDto request, CancellationToken cancellationToken)
    {
        var submission = await _assignmentService.GradeSubmissionAsync(submissionId, request, cancellationToken);
        return Ok(submission);
    }
}
