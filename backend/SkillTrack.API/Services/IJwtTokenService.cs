using SkillTrack.API.Models;

namespace SkillTrack.API.Services;

/// <summary>
/// Generates the JWT issued on register/login. Reads Issuer/Audience/Key/
/// expiration from the "Jwt" section of appsettings.json.
/// </summary>
public interface IJwtTokenService
{
    /// <summary>Signed JWT for this user - includes Id, Email and Role as claims
    /// so [Authorize(Roles = "Admin")] works once auth middleware is wired up.</summary>
    string GenerateToken(User user);

    DateTime GetTokenExpirationUtc();
}
