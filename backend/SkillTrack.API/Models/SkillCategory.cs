
namespace SkillTrack.API.Models;

/// <summary>Groups skills (e.g. "Technical Skills", "Academic Skills", "Professional Skills").</summary>
public class SkillCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
