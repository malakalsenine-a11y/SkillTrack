using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

public class UpdateResourceRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public ResourceType Type { get; set; }
}
