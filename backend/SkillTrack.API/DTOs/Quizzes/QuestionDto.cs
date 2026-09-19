using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

/// <summary>Admin-facing question shape - includes correct answers. Used when
/// building/editing a quiz, never sent to a learner mid-attempt.</summary>
public class QuestionDto
{
    public Guid Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public QuestionType Type { get; set; }

    public int Score { get; set; }

    public string? Explanation { get; set; }

    public Guid QuizId { get; set; }

    public List<QuizOptionDto> Options { get; set; } = new();
}
