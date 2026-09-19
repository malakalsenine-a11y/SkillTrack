using SkillTrack.API.DTOs;

namespace SkillTrack.API.Services;

public interface IModuleService
{
    Task<ModuleDetailDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ModuleDto>> GetByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default);

    /// <summary>OrderIndex is assigned server-side (next position in the path) -
    /// see IModuleRepository.GetNextOrderIndexAsync.</summary>
    Task<ModuleDto> CreateAsync(CreateModuleRequestDto request, CancellationToken cancellationToken = default);

    Task<ModuleDto> UpdateAsync(Guid id, UpdateModuleRequestDto request, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
