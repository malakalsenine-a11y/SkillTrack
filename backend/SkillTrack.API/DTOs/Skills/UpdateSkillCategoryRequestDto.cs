namespace SkillTrack.API.DTOs;

public class UpdateSkillCategoryRequestDto
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}
