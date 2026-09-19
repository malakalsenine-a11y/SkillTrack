using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;

namespace SkillTrack.API.Services;

public interface IAssignmentService
{
    Task<AssignmentDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<AssignmentDto>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default);

    Task<AssignmentDto> CreateAsync(CreateAssignmentRequestDto request, CancellationToken cancellationToken = default);

    Task<AssignmentDto> UpdateAsync(Guid id, UpdateAssignmentRequestDto request, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>Creates or updates the learner's submission and sets status to
    /// Submitted (spec section 10 - submission statuses).</summary>
    Task<AssignmentSubmissionDto> SubmitAsync(Guid userId, SubmitAssignmentRequestDto request, CancellationToken cancellationToken = default);

    Task<AssignmentSubmissionDto?> GetSubmissionByUserAsync(Guid userId, Guid assignmentId, CancellationToken cancellationToken = default);

    /// <summary>Admin review queue, optionally filtered by status, paged.</summary>
    Task<PagedResult<AssignmentSubmissionDto>> GetForReviewAsync(
        SubmissionStatus? status,
        Guid? assignmentId,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);

    /// <summary>Admin grades a submission - sets Grade, Feedback, GradedAt, and
    /// moves Status to Graded.</summary>
    Task<AssignmentSubmissionDto> GradeSubmissionAsync(Guid submissionId, GradeAssignmentRequestDto request, CancellationToken cancellationToken = default);
}
