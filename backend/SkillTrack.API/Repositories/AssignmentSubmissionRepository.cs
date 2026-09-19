using SkillTrack.API.Data;
using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class AssignmentSubmissionRepository : GenericRepository<AssignmentSubmission>, IAssignmentSubmissionRepository
{
    public AssignmentSubmissionRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<AssignmentSubmission?> GetByUserAndAssignmentAsync(Guid userId, Guid assignmentId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<AssignmentSubmission>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<AssignmentSubmission?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PagedResult<AssignmentSubmission>> GetForReviewAsync(
        SubmissionStatus? status,
        Guid? assignmentId,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountByStatusAsync(SubmissionStatus status, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountGradedByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<double> GetAverageGradeByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
