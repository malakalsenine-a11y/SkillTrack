namespace SkillTrack.API.DTOs;

public class UpdateLessonRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public int OrderIndex { get; set; }
}
