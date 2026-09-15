using SkillTrack.Domain.Common;

namespace SkillTrack.Domain.Entities;

/// <summary>A practical, non-quiz task within a Module (e.g. "Find three reliable sources...").</summary>
public class Assignment : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    /// <summary>The instructions/prompt shown to the learner.</summary>
    public string Description { get; set; } = string.Empty;

    public int MaxScore { get; set; } = 10;

    public Guid ModuleId { get; set; }
    public Module Module { get; set; } = null!;

    public ICollection<AssignmentSubmission> Submissions { get; set; } = new List<AssignmentSubmission>();
}
