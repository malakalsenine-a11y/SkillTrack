namespace SkillTrack.API.DTOs;

/// <summary>Lightweight row for the attempt-history list (spec section 9 - Attempt
/// 1: 55%, Attempt 2: 72%, ...) without loading every answer for every attempt.</summary>
public class QuizAttemptSummaryDto
{
    public Guid Id { get; set; }

    public DateTime AttemptedAt { get; set; }

    public double PercentageScore { get; set; }

    public bool Passed { get; set; }
}
