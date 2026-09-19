using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class UpdateQuestionRequestDto
{
    public string Text { get; set; } = string.Empty;

    public QuestionType Type { get; set; }

    public int Score { get; set; }

    public string? Explanation { get; set; }

    public List<CreateQuizOptionRequestDto> Options { get; set; } = new();
}
