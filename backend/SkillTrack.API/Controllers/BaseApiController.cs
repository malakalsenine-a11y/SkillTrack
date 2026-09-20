using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace SkillTrack.API.Controllers;

/// <summary>
/// Base for any controller that needs to know which user is calling it.
/// Relies on JwtTokenService putting the user's Id in a ClaimTypes.NameIdentifier
/// claim when it generates the token (see Services/JwtTokenService.cs).
/// </summary>
[ApiController]
public abstract class BaseApiController : ControllerBase
{
    protected Guid GetCurrentUserId()
    {
        var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)
            ?? throw new InvalidOperationException("No NameIdentifier claim found on the current user.");

        return Guid.Parse(idClaim.Value);
    }
}
