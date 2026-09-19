using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class QuestionForAttemptDto
{
    public Guid Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public QuestionType Type { get; set; }

    public List<OptionForAttemptDto> Options { get; set; } = new();
}
