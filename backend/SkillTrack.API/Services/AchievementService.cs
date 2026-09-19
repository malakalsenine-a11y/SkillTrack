using SkillTrack.API.DTOs;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class AchievementService : IAchievementService
{
    private readonly IAchievementRepository _achievementRepository;
    private readonly IUserAchievementRepository _userAchievementRepository;

    public AchievementService(
        IAchievementRepository achievementRepository,
        IUserAchievementRepository userAchievementRepository)
    {
        _achievementRepository = achievementRepository;
        _userAchievementRepository = userAchievementRepository;
    }

    public Task<IReadOnlyList<AchievementDto>> GetAllAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<AchievementDto> CreateAsync(CreateAchievementRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<AchievementDto> UpdateAsync(Guid id, UpdateAchievementRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<UserAchievementDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task CheckAndAwardAchievementsAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
