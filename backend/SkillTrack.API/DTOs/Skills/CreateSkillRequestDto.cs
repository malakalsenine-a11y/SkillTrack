using System.ComponentModel.DataAnnotations;
using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class CreateSkillRequestDto
{
    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    [EnumDataType(typeof(DifficultyLevel))]
    public DifficultyLevel DifficultyLevel { get; set; }

    // No [Required] here - it's a no-op on a non-nullable Guid. Whether this
    // SkillCategoryId actually refers to a real category is validated in
    // SkillService (KeyNotFoundException -> 404), not via a data annotation.
    public Guid SkillCategoryId { get; set; }
}