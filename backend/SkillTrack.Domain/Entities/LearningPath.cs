using SkillTrack.Domain.Common;
using SkillTrack.Domain.Enums;

namespace SkillTrack.Domain.Entities;

/// <summary>A structured journey (modules -> lessons -> quizzes/assignments) that teaches a skill.</summary>
public class LearningPath : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DifficultyLevel DifficultyLevel { get; set; } = DifficultyLevel.Beginner;

    /// <summary>The primary skill this path teaches. Nullable so a path can exist
    /// before being linked, though in practice it should always be set.</summary>
    public Guid? SkillId { get; set; }
    public Skill? Skill { get; set; }

    public ICollection<Module> Modules { get; set; } = new List<Module>();
    public ICollection<UserLearningPath> UserLearningPaths { get; set; } = new List<UserLearningPath>();
}
