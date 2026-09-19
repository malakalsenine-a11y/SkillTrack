using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class UserSkillRepository : GenericRepository<UserSkill>, IUserSkillRepository
{
    public UserSkillRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<UserSkill?> GetByUserAndSkillAsync(Guid userId, Guid skillId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<UserSkill>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountCompletedByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountInProgressByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountUsersBySkillAsync(Guid skillId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
