
namespace SkillTrack.API.Models;

/// <summary>A single attempt by a user at a quiz. Multiple attempts per user/quiz
/// are allowed and all are kept - history matters (see spec section 9).</summary>
public class QuizAttempt : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid QuizId { get; set; }
    public Quiz Quiz { get; set; } = null!;

    /// <summary>Raw points earned.</summary>
    public int Score { get; set; }

    /// <summary>Total points possible for this quiz at the time of the attempt.</summary>
    public int TotalScore { get; set; }

    public double PercentageScore { get; set; }

    public bool Passed { get; set; }

    public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;

    public ICollection<QuizAnswer> Answers { get; set; } = new List<QuizAnswer>();
}
