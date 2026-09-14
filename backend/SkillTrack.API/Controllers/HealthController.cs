using Microsoft.AspNetCore.Mvc;

namespace SkillTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    /// <summary>
    /// Confirms the API is running and the solution wiring (Application/Infrastructure
    /// references, DI, controllers) works end to end before we build real features.
    /// </summary>
    [HttpGet]
    public IActionResult Get() => Ok(new
    {
        status = "healthy",
        service = "SkillTrack.API",
        timestampUtc = DateTime.UtcNow
    });
}
