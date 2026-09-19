using SkillTrack.API.DTOs;

namespace SkillTrack.API.Services;

public interface IGoalService
{
    Task<IReadOnlyList<GoalDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Ownership-safe fetch - returns null if the goal isn't this user's.</summary>
    Task<GoalDto?> GetByIdAsync(Guid id, Guid userId, CancellationToken cancellationToken = default);

    Task<GoalDto> CreateAsync(Guid userId, CreateGoalRequestDto request, CancellationToken cancellationToken = default);

    Task<GoalDto> UpdateAsync(Guid id, Guid userId, UpdateGoalRequestDto request, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, Guid userId, CancellationToken cancellationToken = default);
}
