using System.Linq.Expressions;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

/// <summary>
/// Generic data-access contract. Entity-specific repositories (IUserRepository,
/// ISkillRepository, ...) will extend this and add queries particular to that
/// entity as each feature is built.
/// </summary>
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    void Update(T entity);

    void Remove(T entity);

    /// <summary>Persists changes made through this repository. EF Core's DbContext
    /// already acts as a unit of work, so there's no separate IUnitOfWork here -
    /// that would just be an extra layer wrapping the same SaveChangesAsync call.</summary>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
