
namespace SkillTrack.API.Models;

/// <summary>One possible answer for a Question. For True/False questions there are
/// exactly two options; for Multiple Choice, typically 3-5.</summary>
public class QuizOption : BaseEntity
{
    public string Text { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }

    public Guid QuestionId { get; set; }
    public Question Question { get; set; } = null!;
}
