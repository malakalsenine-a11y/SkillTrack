namespace SkillTrack.API.DTOs;

/// <summary>Returned after successful register/login - the JWT plus enough user
/// info for the frontend to populate the header/profile without another call.</summary>
public class AuthResponseDto
{
    public string Token { get; set; } = string.Empty;

    public DateTime ExpiresAtUtc { get; set; }

    public UserDto User { get; set; } = null!;
}
