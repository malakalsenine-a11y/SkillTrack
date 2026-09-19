using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
{
    public AssignmentRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<Assignment>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<Assignment?> GetByIdWithSubmissionsAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
