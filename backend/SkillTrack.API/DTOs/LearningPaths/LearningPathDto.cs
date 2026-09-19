using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

/// <summary>Summary shape for list pages (browse learning paths, search results).</summary>
public class LearningPathDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DifficultyLevel DifficultyLevel { get; set; }

    public Guid? SkillId { get; set; }

    public string? SkillName { get; set; }

    public int ModuleCount { get; set; }
}
