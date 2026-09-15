using SkillTrack.API.Enums;

namespace SkillTrack.API.Models;

public class Question : BaseEntity
{
    public string Text { get; set; } = string.Empty;

    public QuestionType Type { get; set; } = QuestionType.MultipleChoice;

    /// <summary>Points this question is worth toward the quiz's total score.</summary>
    public int Score { get; set; } = 1;

    public string? Explanation { get; set; }

    public Guid QuizId { get; set; }
    public Quiz Quiz { get; set; } = null!;

    public ICollection<QuizOption> Options { get; set; } = new List<QuizOption>();
    public ICollection<QuizAnswer> QuizAnswers { get; set; } = new List<QuizAnswer>();
}
