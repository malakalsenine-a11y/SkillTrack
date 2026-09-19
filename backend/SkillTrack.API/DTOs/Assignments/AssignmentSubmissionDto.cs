using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class AssignmentSubmissionDto
{
    public Guid Id { get; set; }

    public Guid AssignmentId { get; set; }

    public string AssignmentTitle { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public string UserFullName { get; set; } = string.Empty;

    public string? SubmissionText { get; set; }

    public string? FileUrl { get; set; }

    public SubmissionStatus Status { get; set; }

    public int? Grade { get; set; }

    public string? Feedback { get; set; }

    public DateTime? SubmittedAt { get; set; }

    public DateTime? GradedAt { get; set; }
}
