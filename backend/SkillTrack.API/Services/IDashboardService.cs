using SkillTrack.API.DTOs;

namespace SkillTrack.API.Services;

public interface IDashboardService
{
    /// <summary>Full learner dashboard payload (spec section 15) in one call.</summary>
    Task<UserDashboardDto> GetUserDashboardAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Full admin dashboard payload (spec section 17) in one call.</summary>
    Task<AdminDashboardDto> GetAdminDashboardAsync(CancellationToken cancellationToken = default);
}
