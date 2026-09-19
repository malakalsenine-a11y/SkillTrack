using SkillTrack.API.DTOs;

namespace SkillTrack.API.Services;

public interface IAchievementService
{
    Task<IReadOnlyList<AchievementDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<AchievementDto> CreateAsync(CreateAchievementRequestDto request, CancellationToken cancellationToken = default);

    Task<AchievementDto> UpdateAsync(Guid id, UpdateAchievementRequestDto request, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<UserAchievementDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Rule-based awarding (spec section 14): checks the user's current
    /// activity counts against each achievement's criteria and awards any newly
    /// earned ones. Called after activities that could trigger an achievement -
    /// e.g. from QuizService.SubmitAttemptAsync, LessonService.MarkCompleteAsync.</summary>
    Task CheckAndAwardAchievementsAsync(Guid userId, CancellationToken cancellationToken = default);
}
