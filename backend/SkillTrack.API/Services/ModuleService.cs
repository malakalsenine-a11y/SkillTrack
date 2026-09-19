using SkillTrack.API.DTOs;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;

    public ModuleService(IModuleRepository moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }

    public Task<ModuleDetailDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<ModuleDto>> GetByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ModuleDto> CreateAsync(CreateModuleRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ModuleDto> UpdateAsync(Guid id, UpdateModuleRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
