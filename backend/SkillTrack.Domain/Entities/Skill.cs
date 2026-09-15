using SkillTrack.Domain.Common;
using SkillTrack.Domain.Enums;

namespace SkillTrack.Domain.Entities;

/// <summary>A learnable skill (e.g. "Angular", "Scientific Research"). Belongs to a category.</summary>
public class Skill : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DifficultyLevel DifficultyLevel { get; set; } = DifficultyLevel.Beginner;

    public Guid SkillCategoryId { get; set; }
    public SkillCategory SkillCategory { get; set; } = null!;

    public ICollection<LearningPath> LearningPaths { get; set; } = new List<LearningPath>();
    public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
}
