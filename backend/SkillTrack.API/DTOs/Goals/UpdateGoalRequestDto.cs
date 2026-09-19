namespace SkillTrack.API.DTOs;

public class UpdateGoalRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime? TargetDate { get; set; }
}
