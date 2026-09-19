namespace SkillTrack.API.DTOs;

/// <summary>One line of the weak/strong areas breakdown (spec section 16), e.g.
/// "Academic Referencing: 58%". The same shape serves both lists.</summary>
public class WeakStrongAreaDto
{
    public string Name { get; set; } = string.Empty;

    public double ScorePercentage { get; set; }
}
