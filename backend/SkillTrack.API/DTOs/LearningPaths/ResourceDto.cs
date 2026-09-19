using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class ResourceDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public ResourceType Type { get; set; }

    public Guid LessonId { get; set; }
}
