namespace SkillTrack.API.DTOs;

/// <summary>Served when a learner starts a quiz - deliberately excludes which
/// option is correct and any Score/Explanation fields.</summary>
public class QuizForAttemptDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int PassingScorePercentage { get; set; }

    public List<QuestionForAttemptDto> Questions { get; set; } = new();
}
