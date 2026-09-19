using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class SkillProgressDto
{
    public Guid SkillId { get; set; }

    public string SkillName { get; set; } = string.Empty;

    public double ProgressPercentage { get; set; }

    public ProgressStatus Status { get; set; }

    public DateTime? LastActivityAt { get; set; }
}
