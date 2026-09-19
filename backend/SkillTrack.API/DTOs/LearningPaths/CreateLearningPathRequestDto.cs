using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class CreateLearningPathRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DifficultyLevel DifficultyLevel { get; set; }

    public Guid? SkillId { get; set; }
}
