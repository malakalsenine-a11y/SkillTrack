using SkillTrack.Domain.Common;

namespace SkillTrack.Domain.Entities;

/// <summary>Records that a specific user earned a specific achievement, and when.</summary>
public class UserAchievement : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid AchievementId { get; set; }
    public Achievement Achievement { get; set; } = null!;

    public DateTime EarnedAt { get; set; } = DateTime.UtcNow;
}
