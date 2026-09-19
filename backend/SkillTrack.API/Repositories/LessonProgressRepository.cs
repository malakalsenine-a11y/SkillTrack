using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class LessonProgressRepository : GenericRepository<LessonProgress>, ILessonProgressRepository
{
    public LessonProgressRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<LessonProgress?> GetByUserAndLessonAsync(Guid userId, Guid lessonId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<LessonProgress>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<LessonProgress>> GetByUserAndLearningPathAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountCompletedByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountCompletedInLearningPathAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountCompletedInModuleAsync(Guid userId, Guid moduleId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<DateTime>> GetCompletionDatesByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
