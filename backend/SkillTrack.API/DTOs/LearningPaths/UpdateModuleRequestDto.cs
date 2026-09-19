namespace SkillTrack.API.DTOs;

public class UpdateModuleRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int OrderIndex { get; set; }
}
