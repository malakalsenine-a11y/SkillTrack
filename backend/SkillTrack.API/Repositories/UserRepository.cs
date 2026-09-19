using Microsoft.EntityFrameworkCore;
using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(SkillTrackDbContext context)
        : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(
            u => u.Email == email,
            cancellationToken);
    }

    public async Task<bool> EmailExistsAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(
            u => u.Email == email,
            cancellationToken);
    }
}