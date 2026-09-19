namespace SkillTrack.API.DTOs;

public class AssignmentDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int MaxScore { get; set; }

    public Guid ModuleId { get; set; }
}
