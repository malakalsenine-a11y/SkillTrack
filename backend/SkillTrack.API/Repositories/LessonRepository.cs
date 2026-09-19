using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
{
    public LessonRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<Lesson>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<Lesson?> GetByIdWithResourcesAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> GetNextOrderIndexAsync(Guid moduleId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<Lesson>> GetOrderedByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
