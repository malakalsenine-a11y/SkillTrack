using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class UpdateSkillRequestDto
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DifficultyLevel DifficultyLevel { get; set; }

    public Guid SkillCategoryId { get; set; }
}
