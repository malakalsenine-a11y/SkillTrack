using SkillTrack.API.Enums;

namespace SkillTrack.API.Models;

/// <summary>A personal learning goal a user sets for themselves (e.g. "Learn Angular").</summary>
public class Goal : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime? TargetDate { get; set; }

    public double ProgressPercentage { get; set; }

    public GoalStatus Status { get; set; } = GoalStatus.NotStarted;

    /// <summary>Optional link if this goal tracks a specific learning path's completion.</summary>
    public Guid? LearningPathId { get; set; }
    public LearningPath? LearningPath { get; set; }

    /// <summary>Optional link if this goal tracks a specific skill's progress.</summary>
    public Guid? SkillId { get; set; }
    public Skill? Skill { get; set; }
}
