using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/dashboard")]
[Authorize]
public class DashboardController : BaseApiController
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    /// <summary>Full learner dashboard payload (spec section 15) in one call.</summary>
    [HttpGet]
    public async Task<ActionResult<UserDashboardDto>> GetMyDashboard(CancellationToken cancellationToken)
    {
        var dashboard = await _dashboardService.GetUserDashboardAsync(GetCurrentUserId(), cancellationToken);
        return Ok(dashboard);
    }

    /// <summary>Full admin dashboard payload (spec section 17) in one call.</summary>
    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<AdminDashboardDto>> GetAdminDashboard(CancellationToken cancellationToken)
    {
        var dashboard = await _dashboardService.GetAdminDashboardAsync(cancellationToken);
        return Ok(dashboard);
    }
}
