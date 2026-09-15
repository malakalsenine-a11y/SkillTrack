using SkillTrack.Domain.Common;
using SkillTrack.Domain.Enums;

namespace SkillTrack.Domain.Entities;

/// <summary>Tracks one user's enrollment and progress in one learning path.</summary>
public class UserLearningPath : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid LearningPathId { get; set; }
    public LearningPath LearningPath { get; set; } = null!;

    public double ProgressPercentage { get; set; }

    public ProgressStatus Status { get; set; } = ProgressStatus.NotStarted;

    public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

    public DateTime? CompletedAt { get; set; }
}
