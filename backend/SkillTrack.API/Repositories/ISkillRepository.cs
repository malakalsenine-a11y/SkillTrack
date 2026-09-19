using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface ISkillRepository : IGenericRepository<Skill>
{
    Task<Skill?> GetByIdWithCategoryAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>Server-side search + filtering + pagination (spec section 18).</summary>
    Task<PagedResult<Skill>> SearchAsync(
        string? searchTerm,
        Guid? categoryId,
        DifficultyLevel? difficulty,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Skill>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default);

    Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null, CancellationToken cancellationToken = default);

    /// <summary>Most-enrolled skills, for the admin dashboard.</summary>
    Task<IReadOnlyList<Skill>> GetMostPopularAsync(int count, CancellationToken cancellationToken = default);
}
