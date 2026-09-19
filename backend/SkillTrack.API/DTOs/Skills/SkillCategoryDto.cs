namespace SkillTrack.API.DTOs;

public class SkillCategoryDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int SkillCount { get; set; }
}
