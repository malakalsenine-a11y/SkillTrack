using Microsoft.EntityFrameworkCore;
using SkillTrack.Domain.Common;

namespace SkillTrack.Infrastructure.Persistence;

/// <summary>
/// EF Core database context for SkillTrack. DbSets are added incrementally as
/// each domain module (Users, Skills, LearningPaths, Quizzes, ...) is modeled.
/// Entity configurations live in Persistence/Configurations and are applied
/// automatically via ApplyConfigurationsFromAssembly below.
/// </summary>
public class SkillTrackDbContext : DbContext
{
    public SkillTrackDbContext(DbContextOptions<SkillTrackDbContext> options)
        : base(options)
    {
    }

    // DbSet<User> Users => Set<User>();
    // DbSet<Skill> Skills => Set<Skill>();
    // DbSet<LearningPath> LearningPaths => Set<LearningPath>();
    // ... added as each module is built

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkillTrackDbContext).Assembly);
    }

    public override int SaveChanges()
    {
        UpdateAuditFields();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditFields()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
