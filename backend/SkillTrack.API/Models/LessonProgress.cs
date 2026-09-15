using SkillTrack.API.Enums;

namespace SkillTrack.API.Models;

/// <summary>Tracks one user's completion status for one lesson.</summary>
public class LessonProgress : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;

    public ProgressStatus Status { get; set; } = ProgressStatus.NotStarted;

    public DateTime? CompletedAt { get; set; }
}
