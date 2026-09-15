using SkillTrack.Domain.Common;

namespace SkillTrack.Domain.Entities;

/// <summary>Definition of an awardable achievement (e.g. "First Quiz Completed").
/// The actual award-to-user link is UserAchievement.</summary>
public class Achievement : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? IconUrl { get; set; }

    public ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
}
