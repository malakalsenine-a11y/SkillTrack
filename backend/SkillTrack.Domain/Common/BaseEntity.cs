namespace SkillTrack.Domain.Common;

/// <summary>
/// Base class for all domain entities. Centralizes the primary key and
/// audit fields so every entity behaves consistently.
/// </summary>
public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}
