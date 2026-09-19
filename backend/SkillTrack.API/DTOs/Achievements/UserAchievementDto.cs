namespace SkillTrack.API.DTOs;

/// <summary>An achievement as earned by a specific user - what shows on their
/// Achievements page and dashboard.</summary>
public class UserAchievementDto
{
    public Guid AchievementId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? IconUrl { get; set; }

    public DateTime EarnedAt { get; set; }
}
