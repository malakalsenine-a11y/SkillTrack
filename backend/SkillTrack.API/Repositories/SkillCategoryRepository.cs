using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class SkillCategoryRepository : GenericRepository<SkillCategory>, ISkillCategoryRepository
{
    public SkillCategoryRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<SkillCategory>> GetAllWithSkillsAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<SkillCategory?> GetByIdWithSkillsAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
