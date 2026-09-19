using SkillTrack.API.DTOs;

namespace SkillTrack.API.Services;

public interface ISkillCategoryService
{
    Task<IReadOnlyList<SkillCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<SkillCategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<SkillCategoryDto> CreateAsync(CreateSkillCategoryRequestDto request, CancellationToken cancellationToken = default);

    Task<SkillCategoryDto> UpdateAsync(Guid id, UpdateSkillCategoryRequestDto request, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
