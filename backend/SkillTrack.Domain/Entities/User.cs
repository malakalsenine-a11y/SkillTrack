using SkillTrack.Domain.Common;
using SkillTrack.Domain.Enums;

namespace SkillTrack.Domain.Entities;

/// <summary>
/// Represents a registered SkillTrack account.
/// A user can be either a Learner or an Admin.
/// </summary>
public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Used as the login identifier.
    /// Email uniqueness will be enforced later in EF Core configuration.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Stores the hashed password only.
    /// Plain-text passwords should never be stored.
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    public UserRole Role { get; set; } = UserRole.Learner;

    public string? ProfilePictureUrl { get; set; }

    public string? Bio { get; set; }

    /// <summary>
    /// Allows an admin to disable the account without deleting its history.
    /// </summary>
    public bool IsActive { get; set; } = true;

    public string FullName => $"{FirstName} {LastName}";
}