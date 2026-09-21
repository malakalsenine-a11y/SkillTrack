using System.ComponentModel.DataAnnotations;

namespace SkillTrack.API.DTOs;

public class UpdateProfileRequestDto
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Bio { get; set; }

    [MaxLength(500)]
    public string? ProfilePictureUrl { get; set; }
}