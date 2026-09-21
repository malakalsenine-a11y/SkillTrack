using SkillTrack.API.DTOs;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>Search by name/email + paginate - backs the admin "Manage users"
    /// list (spec section 4.2/18). Filtering and paging happen in SQL, not after
    /// loading everything into memory.</summary>
    Task<PagedResult<User>> SearchAsync(string? searchTerm, int page, int pageSize, CancellationToken cancellationToken = default);
}