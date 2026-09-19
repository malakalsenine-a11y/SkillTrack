using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IUserSkillRepository : IGenericRepository<UserSkill>
{
    Task<UserSkill?> GetByUserAndSkillAsync(Guid userId, Guid skillId, CancellationToken cancellationToken = default);

    /// <summary>All skills this user is tracking, including Skill details (My Skills page).</summary>
    Task<IReadOnlyList<UserSkill>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<int> CountCompletedByUserAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<int> CountInProgressByUserAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>How many users are tracking a given skill - "most popular skills" stat.</summary>
    Task<int> CountUsersBySkillAsync(Guid skillId, CancellationToken cancellationToken = default);
}
