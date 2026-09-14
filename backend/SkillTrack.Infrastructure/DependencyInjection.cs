using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillTrack.Application.Interfaces.Repositories;
using SkillTrack.Infrastructure.Persistence;
using SkillTrack.Infrastructure.Repositories;

namespace SkillTrack.Infrastructure;

/// <summary>
/// Registers everything the Infrastructure layer provides (DbContext, repositories,
/// unit of work, identity/JWT services as they're added) so SkillTrack.API only
/// has to call AddInfrastructure(configuration) once in Program.cs.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SkillTrackDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Entity-specific repositories (IUserRepository, ISkillRepository, ...) and
        // JWT/identity services are registered here as each module is built.

        return services;
    }
}
