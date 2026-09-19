namespace SkillTrack.API.DTOs;

/// <summary>One row of the "Recent activity" feed on the learner dashboard, e.g.
/// "Completed lesson: Research Process" / "Scored 80% on Academic Referencing quiz".</summary>
public class RecentActivityDto
{
    public string ActivityType { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime OccurredAt { get; set; }
}
