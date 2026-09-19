using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class SkillService : ISkillService
{
    private readonly ISkillRepository _skillRepository;

    public SkillService(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public Task<SkillDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PagedResult<SkillDto>> SearchAsync(
        string? searchTerm,
        Guid? categoryId,
        DifficultyLevel? difficulty,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<SkillDto> CreateAsync(CreateSkillRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<SkillDto> UpdateAsync(Guid id, UpdateSkillRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<SkillDto>> GetMostPopularAsync(int count, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
