using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class ModuleRepository : GenericRepository<Module>, IModuleRepository
{
    public ModuleRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<Module>> GetByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<Module?> GetByIdWithContentAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> GetNextOrderIndexAsync(Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
