namespace SkillTrack.API.DTOs;

/// <summary>Per-question breakdown shown on the quiz results page - reveals the
/// correct answer now that the attempt is graded.</summary>
public class QuizAnswerResultDto
{
    public Guid QuestionId { get; set; }

    public string QuestionText { get; set; } = string.Empty;

    public Guid? SelectedOptionId { get; set; }

    public string? SelectedOptionText { get; set; }

    public bool IsCorrect { get; set; }

    public string CorrectOptionText { get; set; } = string.Empty;

    public string? Explanation { get; set; }
}
