using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class LearningPathService : ILearningPathService
{
    private readonly ILearningPathRepository _learningPathRepository;
    private readonly IUserLearningPathRepository _userLearningPathRepository;

    public LearningPathService(
        ILearningPathRepository learningPathRepository,
        IUserLearningPathRepository userLearningPathRepository)
    {
        _learningPathRepository = learningPathRepository;
        _userLearningPathRepository = userLearningPathRepository;
    }

    public Task<LearningPathDetailDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PagedResult<LearningPathDto>> SearchAsync(
        string? searchTerm,
        Guid? skillId,
        DifficultyLevel? difficulty,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<LearningPathDto> CreateAsync(CreateLearningPathRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<LearningPathDto> UpdateAsync(Guid id, UpdateLearningPathRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<LearningPathDto>> GetMostPopularAsync(int count, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task EnrollUserAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
