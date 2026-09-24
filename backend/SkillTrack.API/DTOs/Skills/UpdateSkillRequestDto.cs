using System.ComponentModel.DataAnnotations;
using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class UpdateSkillRequestDto
{
    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    [EnumDataType(typeof(DifficultyLevel))]
    public DifficultyLevel DifficultyLevel { get; set; }

    public Guid SkillCategoryId { get; set; }
}