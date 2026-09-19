namespace SkillTrack.API.DTOs;

public class UpdateAchievementRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? IconUrl { get; set; }
}
