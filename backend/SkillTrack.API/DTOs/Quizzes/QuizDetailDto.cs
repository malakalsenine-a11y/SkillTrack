namespace SkillTrack.API.DTOs;

/// <summary>Full admin view of a quiz - all questions with correct answers shown.</summary>
public class QuizDetailDto : QuizDto
{
    public List<QuestionDto> Questions { get; set; } = new();
}
