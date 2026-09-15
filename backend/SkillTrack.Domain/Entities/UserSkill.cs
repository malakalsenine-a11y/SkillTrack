using SkillTrack.Domain.Common;
using SkillTrack.Domain.Enums;

namespace SkillTrack.Domain.Entities;

/// <summary>Tracks one user's progress on one skill.</summary>
public class UserSkill : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid SkillId { get; set; }
    public Skill Skill { get; set; } = null!;

    public double ProgressPercentage { get; set; }

    public ProgressStatus Status { get; set; } = ProgressStatus.NotStarted;

    public DateTime? LastActivityAt { get; set; }
}
