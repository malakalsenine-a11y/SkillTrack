namespace SkillTrack.API.DTOs;

/// <summary>Summary shape - one row within a ModuleDetailDto or an admin quiz list.</summary>
public class QuizDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int PassingScorePercentage { get; set; }

    public Guid ModuleId { get; set; }

    public int QuestionCount { get; set; }
}
