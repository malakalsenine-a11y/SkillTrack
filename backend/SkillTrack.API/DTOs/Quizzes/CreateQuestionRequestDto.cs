using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class CreateQuestionRequestDto
{
    public string Text { get; set; } = string.Empty;

    public QuestionType Type { get; set; }

    public int Score { get; set; } = 1;

    public string? Explanation { get; set; }

    public Guid QuizId { get; set; }

    public List<CreateQuizOptionRequestDto> Options { get; set; } = new();
}
