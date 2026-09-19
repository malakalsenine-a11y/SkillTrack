using SkillTrack.API.Data;
using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class SkillRepository : GenericRepository<Skill>, ISkillRepository
{
    public SkillRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<Skill?> GetByIdWithCategoryAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PagedResult<Skill>> SearchAsync(
        string? searchTerm,
        Guid? categoryId,
        DifficultyLevel? difficulty,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<Skill>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<Skill>> GetMostPopularAsync(int count, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
