namespace SkillTrack.API.DTOs;

public class LessonDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public int OrderIndex { get; set; }

    public Guid ModuleId { get; set; }
}
