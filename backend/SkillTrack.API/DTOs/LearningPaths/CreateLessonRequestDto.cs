namespace SkillTrack.API.DTOs;

public class CreateLessonRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public Guid ModuleId { get; set; }
}
