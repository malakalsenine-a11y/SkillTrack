namespace SkillTrack.API.DTOs;

/// <summary>A ranked row for "most popular skills" / "most popular learning paths"
/// on the admin dashboard (spec section 17).</summary>
public class PopularItemDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Count { get; set; }
}
