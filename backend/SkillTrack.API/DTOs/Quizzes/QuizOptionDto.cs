namespace SkillTrack.API.DTOs;

/// <summary>Admin-facing option shape - includes IsCorrect. Never send this to a
/// learner who is about to attempt the quiz (use OptionForAttemptDto instead).</summary>
public class QuizOptionDto
{
    public Guid Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }
}
