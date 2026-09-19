using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IResourceRepository : IGenericRepository<Resource>
{
    Task<IReadOnlyList<Resource>> GetByLessonIdAsync(Guid lessonId, CancellationToken cancellationToken = default);
}
