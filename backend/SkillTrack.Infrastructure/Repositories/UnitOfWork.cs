using SkillTrack.Application.Interfaces.Repositories;
using SkillTrack.Infrastructure.Persistence;

namespace SkillTrack.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly SkillTrackDbContext _context;

    public UnitOfWork(SkillTrackDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _context.SaveChangesAsync(cancellationToken);
}
