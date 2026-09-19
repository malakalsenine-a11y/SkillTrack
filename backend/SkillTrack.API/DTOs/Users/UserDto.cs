using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class UserDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public string? Bio { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}
