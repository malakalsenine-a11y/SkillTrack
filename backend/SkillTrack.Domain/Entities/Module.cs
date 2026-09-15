using SkillTrack.Domain.Common;

namespace SkillTrack.Domain.Entities;

/// <summary>A stage within a LearningPath (e.g. "Module 1: Introduction"). Contains
/// lessons, and optionally a quiz and/or assignment.</summary>
public class Module : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    /// <summary>Position of this module within its learning path (1, 2, 3, ...).</summary>
    public int OrderIndex { get; set; }

    public Guid LearningPathId { get; set; }
    public LearningPath LearningPath { get; set; } = null!;

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
}
