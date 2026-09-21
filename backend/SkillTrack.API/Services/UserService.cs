using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Models;
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

    public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        return user is null ? null : MapToUserDto(user);
    }

    public async Task<UserDto> UpdateProfileAsync(Guid userId, UpdateProfileRequestDto request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken)
            ?? throw new KeyNotFoundException("User not found.");

        user.FirstName = request.FirstName.Trim();
        user.LastName = request.LastName.Trim();
        user.Bio = request.Bio;
        user.ProfilePictureUrl = request.ProfilePictureUrl;

        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync(cancellationToken);

        return MapToUserDto(user);
    }

    public async Task ChangePasswordAsync(Guid userId, ChangePasswordRequestDto request, CancellationToken cancellationToken = default)
    {
        if (request.NewPassword != request.ConfirmNewPassword)
            throw new ArgumentException("New password and confirmation password do not match.");

        var user = await _userRepository.GetByIdAsync(userId, cancellationToken)
            ?? throw new KeyNotFoundException("User not found.");

        if (!_passwordHasher.VerifyPassword(request.CurrentPassword, user.PasswordHash))
            throw new UnauthorizedAccessException("Current password is incorrect.");

        user.PasswordHash = _passwordHasher.HashPassword(request.NewPassword);

        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<PagedResult<AdminUserListItemDto>> GetAllUsersAsync(string? searchTerm, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var result = await _userRepository.SearchAsync(searchTerm, page, pageSize, cancellationToken);

        return new PagedResult<AdminUserListItemDto>
        {
            Items = result.Items.Select(MapToAdminListItem).ToList(),
            TotalCount = result.TotalCount,
            Page = result.Page,
            PageSize = result.PageSize
        };
    }

    public async Task UpdateUserRoleAsync(Guid userId, UpdateUserRoleRequestDto request, CancellationToken cancellationToken = default)
    {
        if (!Enum.IsDefined(typeof(UserRole), request.Role))
            throw new ArgumentException("Invalid role value.");

        var user = await _userRepository.GetByIdAsync(userId, cancellationToken)
            ?? throw new KeyNotFoundException("User not found.");

        user.Role = request.Role;

        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task SetUserActiveStatusAsync(Guid userId, SetUserActiveRequestDto request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken)
            ?? throw new KeyNotFoundException("User not found.");

        user.IsActive = request.IsActive;

        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync(cancellationToken);
    }

    private static UserDto MapToUserDto(User user) => new()
    {
        Id = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        FullName = user.FullName,
        Email = user.Email,
        Role = user.Role,
        ProfilePictureUrl = user.ProfilePictureUrl,
        Bio = user.Bio,
        IsActive = user.IsActive,
        CreatedAt = user.CreatedAt
    };

    private static AdminUserListItemDto MapToAdminListItem(User user) => new()
    {
        Id = user.Id,
        FullName = user.FullName,
        Email = user.Email,
        Role = user.Role,
        IsActive = user.IsActive,
        CreatedAt = user.CreatedAt
    };
}