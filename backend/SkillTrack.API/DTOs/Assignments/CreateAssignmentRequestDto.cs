namespace SkillTrack.API.DTOs;

public class CreateAssignmentRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int MaxScore { get; set; } = 10;

    public Guid ModuleId { get; set; }
}
