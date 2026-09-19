using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IAssignmentSubmissionRepository : IGenericRepository<AssignmentSubmission>
{
    Task<AssignmentSubmission?> GetByUserAndAssignmentAsync(Guid userId, Guid assignmentId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<AssignmentSubmission>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<AssignmentSubmission?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>Admin review queue - filter by status, paged.</summary>
    Task<PagedResult<AssignmentSubmission>> GetForReviewAsync(
        SubmissionStatus? status,
        Guid? assignmentId,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<int> CountByStatusAsync(SubmissionStatus status, CancellationToken cancellationToken = default);

    Task<int> CountGradedByUserAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<double> GetAverageGradeByUserAsync(Guid userId, CancellationToken cancellationToken = default);
}
