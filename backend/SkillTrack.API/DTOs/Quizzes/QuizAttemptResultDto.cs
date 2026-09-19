namespace SkillTrack.API.DTOs;

/// <summary>Full result of one attempt - returned right after submission (spec
/// section 8: score, percentage, passed status) and reusable for the history view.</summary>
public class QuizAttemptResultDto
{
    public Guid Id { get; set; }

    public Guid QuizId { get; set; }

    public string QuizTitle { get; set; } = string.Empty;

    public int Score { get; set; }

    public int TotalScore { get; set; }

    public double PercentageScore { get; set; }

    public bool Passed { get; set; }

    public DateTime AttemptedAt { get; set; }

    public List<QuizAnswerResultDto> Answers { get; set; } = new();
}
