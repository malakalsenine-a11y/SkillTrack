using SkillTrack.Domain.Common;
using SkillTrack.Domain.Enums;

namespace SkillTrack.Domain.Entities;

/// <summary>One user's submission for an Assignment, including admin grading/feedback.</summary>
public class AssignmentSubmission : BaseEntity
{
    public Guid AssignmentId { get; set; }
    public Assignment Assignment { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string? SubmissionText { get; set; }

    /// <summary>Path/URL to an uploaded file, if the submission includes one.</summary>
    public string? FileUrl { get; set; }

    public SubmissionStatus Status { get; set; } = SubmissionStatus.NotSubmitted;

    public int? Grade { get; set; }

    public string? Feedback { get; set; }

    public DateTime? SubmittedAt { get; set; }

    public DateTime? GradedAt { get; set; }
}
