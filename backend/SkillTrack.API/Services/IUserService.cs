using SkillTrack.API.DTOs;

namespace SkillTrack.API.Services;

public interface IUserService
{
    Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UserDto> UpdateProfileAsync(Guid userId, UpdateProfileRequestDto request, CancellationToken cancellationToken = default);

    Task ChangePasswordAsync(Guid userId, ChangePasswordRequestDto request, CancellationToken cancellationToken = default);

    /// <summary>Admin "Manage users" list (spec section 4.2), paged.</summary>
    Task<PagedResult<AdminUserListItemDto>> GetAllUsersAsync(string? searchTerm, int page, int pageSize, CancellationToken cancellationToken = default);

    Task UpdateUserRoleAsync(Guid userId, UpdateUserRoleRequestDto request, CancellationToken cancellationToken = default);

    /// <summary>Soft-delete alternative used by admins - see the Restrict cascade
    /// rules on User in SkillTrackDbContext for why a hard delete is intentionally hard.</summary>
    Task SetUserActiveStatusAsync(Guid userId, SetUserActiveRequestDto request, CancellationToken cancellationToken = default);
}
