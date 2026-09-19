using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class ResourceRepository : GenericRepository<Resource>, IResourceRepository
{
    public ResourceRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<Resource>> GetByLessonIdAsync(Guid lessonId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
