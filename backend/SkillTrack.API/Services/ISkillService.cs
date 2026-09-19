using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;

namespace SkillTrack.API.Services;

public interface ISkillService
{
    Task<SkillDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<PagedResult<SkillDto>> SearchAsync(
        string? searchTerm,
        Guid? categoryId,
        DifficultyLevel? difficulty,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<SkillDto> CreateAsync(CreateSkillRequestDto request, CancellationToken cancellationToken = default);

    Task<SkillDto> UpdateAsync(Guid id, UpdateSkillRequestDto request, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>Admin dashboard "most popular skills" (spec section 17).</summary>
    Task<IReadOnlyList<SkillDto>> GetMostPopularAsync(int count, CancellationToken cancellationToken = default);
}
