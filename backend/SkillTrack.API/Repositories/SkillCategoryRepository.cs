using Microsoft.EntityFrameworkCore;
using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class SkillCategoryRepository : GenericRepository<SkillCategory>, ISkillCategoryRepository
{
    public SkillCategoryRepository(SkillTrackDbContext context) : base(context) { }

    public async Task<IReadOnlyList<SkillCategory>> GetAllWithSkillsAsync(CancellationToken cancellationToken = default)
        => await DbSet.Include(c => c.Skills).OrderBy(c => c.Name).ToListAsync(cancellationToken);

    public async Task<SkillCategory?> GetByIdWithSkillsAsync(Guid id, CancellationToken cancellationToken = default)
        => await DbSet.Include(c => c.Skills).FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null, CancellationToken cancellationToken = default)
    {
        var normalized = name.Trim().ToLower();
        var query = DbSet.Where(c => c.Name.ToLower() == normalized);

        if (excludeId.HasValue)
            query = query.Where(c => c.Id != excludeId.Value);

        return await query.AnyAsync(cancellationToken);
    }
}