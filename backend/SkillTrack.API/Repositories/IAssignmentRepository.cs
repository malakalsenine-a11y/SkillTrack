using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IAssignmentRepository : IGenericRepository<Assignment>
{
    Task<IReadOnlyList<Assignment>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default);

    Task<Assignment?> GetByIdWithSubmissionsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<int> CountByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default);
}
