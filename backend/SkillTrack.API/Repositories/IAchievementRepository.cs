using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IAchievementRepository : IGenericRepository<Achievement>
{
    /// <summary>Lookup by title - how the achievement engine finds the definition
    /// to award (e.g. "First Quiz Completed") without hardcoding Guids.</summary>
    Task<Achievement?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);

    Task<bool> ExistsByTitleAsync(string title, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
