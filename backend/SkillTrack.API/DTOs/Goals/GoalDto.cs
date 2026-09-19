using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class GoalDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime? TargetDate { get; set; }

    public double ProgressPercentage { get; set; }

    public GoalStatus Status { get; set; }

    public Guid? LearningPathId { get; set; }

    public string? LearningPathTitle { get; set; }

    public Guid? SkillId { get; set; }

    public string? SkillName { get; set; }
}
