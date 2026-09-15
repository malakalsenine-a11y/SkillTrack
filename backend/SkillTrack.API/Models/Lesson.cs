
namespace SkillTrack.API.Models;

/// <summary>A single learning unit within a Module (text, video, examples, etc via its Resources).</summary>
public class Lesson : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    /// <summary>The lesson's main written content/body.</summary>
    public string Content { get; set; } = string.Empty;

    public int OrderIndex { get; set; }

    public Guid ModuleId { get; set; }
    public Module Module { get; set; } = null!;

    public ICollection<Resource> Resources { get; set; } = new List<Resource>();
    public ICollection<LessonProgress> LessonProgresses { get; set; } = new List<LessonProgress>();
}
