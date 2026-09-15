namespace SkillTrack.API.Enums;

/// <summary>
/// The two roles in SkillTrack. Kept as an enum (not a string) so role checks
/// are compile-time safe and the JWT/authorization pipeline has a single
/// source of truth for valid values.
/// </summary>
public enum UserRole
{
    Learner = 0,
    Admin = 1
}
