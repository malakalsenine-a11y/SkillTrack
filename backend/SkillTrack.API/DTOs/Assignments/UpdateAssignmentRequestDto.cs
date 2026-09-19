namespace SkillTrack.API.DTOs;

public class UpdateAssignmentRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int MaxScore { get; set; }
}
