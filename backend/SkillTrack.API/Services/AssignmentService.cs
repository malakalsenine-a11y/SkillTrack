using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IAssignmentSubmissionRepository _assignmentSubmissionRepository;

    public AssignmentService(
        IAssignmentRepository assignmentRepository,
        IAssignmentSubmissionRepository assignmentSubmissionRepository)
    {
        _assignmentRepository = assignmentRepository;
        _assignmentSubmissionRepository = assignmentSubmissionRepository;
    }

    public Task<AssignmentDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<AssignmentDto>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<AssignmentDto> CreateAsync(CreateAssignmentRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<AssignmentDto> UpdateAsync(Guid id, UpdateAssignmentRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<AssignmentSubmissionDto> SubmitAsync(Guid userId, SubmitAssignmentRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<AssignmentSubmissionDto?> GetSubmissionByUserAsync(Guid userId, Guid assignmentId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PagedResult<AssignmentSubmissionDto>> GetForReviewAsync(
        SubmissionStatus? status,
        Guid? assignmentId,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<AssignmentSubmissionDto> GradeSubmissionAsync(Guid submissionId, GradeAssignmentRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
