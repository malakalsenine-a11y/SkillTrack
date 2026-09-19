namespace SkillTrack.API.DTOs;

public class UpdateQuizRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int PassingScorePercentage { get; set; }
}
