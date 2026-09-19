namespace SkillTrack.API.DTOs;

public class SubmitAssignmentRequestDto
{
    public Guid AssignmentId { get; set; }

    public string? SubmissionText { get; set; }

    public string? FileUrl { get; set; }
}
