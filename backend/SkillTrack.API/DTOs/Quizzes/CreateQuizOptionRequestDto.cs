namespace SkillTrack.API.DTOs;

public class CreateQuizOptionRequestDto
{
    public string Text { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }
}
