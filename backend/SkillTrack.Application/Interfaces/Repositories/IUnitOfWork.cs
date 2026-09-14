namespace SkillTrack.Application.Interfaces.Repositories;

/// <summary>
/// Commits changes made through one or more repositories in a single transaction.
/// Implemented in Infrastructure by wrapping DbContext.SaveChangesAsync.
/// </summary>
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
