using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class AchievementRepository : GenericRepository<Achievement>, IAchievementRepository
{
    public AchievementRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<Achievement?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<bool> ExistsByTitleAsync(string title, Guid? excludeId = null, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
