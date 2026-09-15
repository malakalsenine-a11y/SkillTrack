using SkillTrack.Domain.Common;

namespace SkillTrack.Domain.Entities;

/// <summary>The answer a user selected for one question within one QuizAttempt.</summary>
public class QuizAnswer : BaseEntity
{
    public Guid QuizAttemptId { get; set; }
    public QuizAttempt QuizAttempt { get; set; } = null!;

    public Guid QuestionId { get; set; }
    public Question Question { get; set; } = null!;

    /// <summary>Null if the user left the question unanswered.</summary>
    public Guid? SelectedOptionId { get; set; }
    public QuizOption? SelectedOption { get; set; }

    public bool IsCorrect { get; set; }
}
