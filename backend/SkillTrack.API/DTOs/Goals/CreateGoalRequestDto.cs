namespace SkillTrack.API.DTOs;

public class CreateGoalRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime? TargetDate { get; set; }

    public Guid? LearningPathId { get; set; }

    public Guid? SkillId { get; set; }
}
