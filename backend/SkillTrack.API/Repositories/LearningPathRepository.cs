using SkillTrack.API.Data;
using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class LearningPathRepository : GenericRepository<LearningPath>, ILearningPathRepository
{
    public LearningPathRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<LearningPath?> GetByIdWithModulesAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<LearningPath?> GetFullPathAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PagedResult<LearningPath>> SearchAsync(
        string? searchTerm,
        Guid? skillId,
        DifficultyLevel? difficulty,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<LearningPath>> GetBySkillIdAsync(Guid skillId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<LearningPath>> GetMostPopularAsync(int count, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
