namespace SkillTrack.API.DTOs;

/// <summary>What a learner sees while taking the quiz - no IsCorrect field.</summary>
public class OptionForAttemptDto
{
    public Guid Id { get; set; }

    public string Text { get; set; } = string.Empty;
}
