using SkillTrack.API.DTOs;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasher;

    public UserService(IUserRepository userRepository, IPasswordHasherService passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<UserDto> UpdateProfileAsync(Guid userId, UpdateProfileRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task ChangePasswordAsync(Guid userId, ChangePasswordRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PagedResult<AdminUserListItemDto>> GetAllUsersAsync(string? searchTerm, int page, int pageSize, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task UpdateUserRoleAsync(Guid userId, UpdateUserRoleRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task SetUserActiveStatusAsync(Guid userId, SetUserActiveRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
