
namespace SkillTrack.API.Models;

public class Quiz : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    /// <summary>Minimum percentage required to pass, e.g. 70.</summary>
    public int PassingScorePercentage { get; set; } = 70;

    public Guid ModuleId { get; set; }
    public Module Module { get; set; } = null!;

    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
}
