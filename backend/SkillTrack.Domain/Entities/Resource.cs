using SkillTrack.Domain.Common;
using SkillTrack.Domain.Enums;

namespace SkillTrack.Domain.Entities;

/// <summary>A supplementary learning resource attached to a lesson (video link, article, doc, ...).</summary>
public class Resource : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public ResourceType Type { get; set; } = ResourceType.Other;

    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;
}
