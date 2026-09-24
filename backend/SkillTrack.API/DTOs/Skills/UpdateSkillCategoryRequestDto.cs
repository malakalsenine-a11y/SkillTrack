using System.ComponentModel.DataAnnotations;

namespace SkillTrack.API.DTOs;

public class UpdateSkillCategoryRequestDto
{
    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }
}