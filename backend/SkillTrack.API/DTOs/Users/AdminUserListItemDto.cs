using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

/// <summary>Row shape for the admin Users page (spec section 4.2 - "Manage users").</summary>
public class AdminUserListItemDto
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}
