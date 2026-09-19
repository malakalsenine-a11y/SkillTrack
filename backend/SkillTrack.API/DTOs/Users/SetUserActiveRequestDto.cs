namespace SkillTrack.API.DTOs;

/// <summary>Admin enable/disable account - the soft-delete alternative to a hard
/// delete (which the Restrict cascade rules on User intentionally make difficult).</summary>
public class SetUserActiveRequestDto
{
    public bool IsActive { get; set; }
}
