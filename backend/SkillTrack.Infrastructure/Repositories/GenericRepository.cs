using Microsoft.EntityFrameworkCore;
using SkillTrack.Application.Interfaces.Repositories;
using SkillTrack.Domain.Common;
using SkillTrack.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace SkillTrack.Infrastructure.Repositories;

/// <summary>
/// Default EF Core implementation of IGenericRepository. Entity-specific
/// repositories inherit from this and add queries particular to that entity.
/// </summary>
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly SkillTrackDbContext Context;
    protected readonly DbSet<T> DbSet;

    public GenericRepository(SkillTrackDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await DbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await DbSet.ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) =>
        await DbSet.Where(predicate).ToListAsync(cancellationToken);

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default) =>
        await DbSet.AddAsync(entity, cancellationToken);

    public void Update(T entity) => DbSet.Update(entity);

    public void Remove(T entity) => DbSet.Remove(entity);
}
