using SkillTrack.API.DTOs;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class SkillCategoryService : ISkillCategoryService
{
    private readonly ISkillCategoryRepository _skillCategoryRepository;

    public SkillCategoryService(ISkillCategoryRepository skillCategoryRepository)
    {
        _skillCategoryRepository = skillCategoryRepository;
    }

    public Task<IReadOnlyList<SkillCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<SkillCategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<SkillCategoryDto> CreateAsync(CreateSkillCategoryRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<SkillCategoryDto> UpdateAsync(Guid id, UpdateSkillCategoryRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
