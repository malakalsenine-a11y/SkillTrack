namespace SkillTrack.API.DTOs;

public class CreateQuizRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int PassingScorePercentage { get; set; } = 70;

    public Guid ModuleId { get; set; }
}
