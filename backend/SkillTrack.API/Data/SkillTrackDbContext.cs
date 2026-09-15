using Microsoft.EntityFrameworkCore;
using SkillTrack.API.Models;

namespace SkillTrack.API.Data;

/// <summary>
/// EF Core database context for SkillTrack. Relationships are configured in
/// OnModelCreating below, grouped by area to keep the model readable as it grows.
///
/// Cascade-delete rule used throughout (kept simple and consistent on purpose):
///   - CASCADE only within the content-authoring hierarchy:
///       LearningPath -> Module -> Lesson -> Resource
///                     -> Module -> Quiz -> Question -> QuizOption
///                     -> Module -> Assignment
///     Deleting a LearningPath/Module/etc. cleans up everything under it — this
///     is what an admin removing a course would expect.
///   - RESTRICT everywhere else (anything touching User, and anything that is a
///     historical record: QuizAttempt, QuizAnswer, AssignmentSubmission,
///     UserAchievement, and the progress-tracking join tables).
///     This means you can't accidentally delete a User/Skill/Quiz/Assignment that
///     still has activity/history attached — the app should soft-delete instead
///     (User already has IsActive for this reason).
/// Keeping ONE consistent rule (instead of deciding cascade behavior per-entity)
/// also avoids SQL Server's "may cause cycles or multiple cascade paths" error,
/// which is easy to trigger by accident once you have this many related tables.
/// </summary>
public class SkillTrackDbContext : DbContext
{
    public SkillTrackDbContext(DbContextOptions<SkillTrackDbContext> options)
        : base(options)
    {
    }

    // Accounts
    public DbSet<User> Users => Set<User>();

    // Catalog
    public DbSet<SkillCategory> SkillCategories => Set<SkillCategory>();
    public DbSet<Skill> Skills => Set<Skill>();

    // Learning structure
    public DbSet<LearningPath> LearningPaths => Set<LearningPath>();
    public DbSet<Module> Modules => Set<Module>();
    public DbSet<Lesson> Lessons => Set<Lesson>();
    public DbSet<Resource> Resources => Set<Resource>();

    // Quizzes
    public DbSet<Quiz> Quizzes => Set<Quiz>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<QuizOption> QuizOptions => Set<QuizOption>();
    public DbSet<QuizAttempt> QuizAttempts => Set<QuizAttempt>();
    public DbSet<QuizAnswer> QuizAnswers => Set<QuizAnswer>();

    // Assignments
    public DbSet<Assignment> Assignments => Set<Assignment>();
    public DbSet<AssignmentSubmission> AssignmentSubmissions => Set<AssignmentSubmission>();

    // Goals & achievements
    public DbSet<Goal> Goals => Set<Goal>();
    public DbSet<Achievement> Achievements => Set<Achievement>();
    public DbSet<UserAchievement> UserAchievements => Set<UserAchievement>();

    // Progress tracking
    public DbSet<UserSkill> UserSkills => Set<UserSkill>();
    public DbSet<UserLearningPath> UserLearningPaths => Set<UserLearningPath>();
    public DbSet<LessonProgress> LessonProgresses => Set<LessonProgress>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureUsers(modelBuilder);
        ConfigureCatalog(modelBuilder);
        ConfigureLearningStructure(modelBuilder);
        ConfigureQuizzes(modelBuilder);
        ConfigureAssignments(modelBuilder);
        ConfigureGoalsAndAchievements(modelBuilder);
        ConfigureProgressTracking(modelBuilder);
    }

    private static void ConfigureUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u => u.Email).HasMaxLength(256).IsRequired();
            entity.Property(u => u.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(u => u.LastName).HasMaxLength(100).IsRequired();
        });
    }

    private static void ConfigureCatalog(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SkillCategory>(entity =>
        {
            entity.Property(c => c.Name).HasMaxLength(150).IsRequired();
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.Property(s => s.Name).HasMaxLength(150).IsRequired();

            entity.HasOne(s => s.SkillCategory)
                  .WithMany(c => c.Skills)
                  .HasForeignKey(s => s.SkillCategoryId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigureLearningStructure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LearningPath>(entity =>
        {
            entity.Property(lp => lp.Title).HasMaxLength(200).IsRequired();

            entity.HasOne(lp => lp.Skill)
                  .WithMany(s => s.LearningPaths)
                  .HasForeignKey(lp => lp.SkillId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.Property(m => m.Title).HasMaxLength(200).IsRequired();

            entity.HasOne(m => m.LearningPath)
                  .WithMany(lp => lp.Modules)
                  .HasForeignKey(m => m.LearningPathId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.Property(l => l.Title).HasMaxLength(200).IsRequired();

            entity.HasOne(l => l.Module)
                  .WithMany(m => m.Lessons)
                  .HasForeignKey(l => l.ModuleId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.Property(r => r.Title).HasMaxLength(200).IsRequired();
            entity.Property(r => r.Url).HasMaxLength(1000).IsRequired();

            entity.HasOne(r => r.Lesson)
                  .WithMany(l => l.Resources)
                  .HasForeignKey(r => r.LessonId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void ConfigureQuizzes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.Property(q => q.Title).HasMaxLength(200).IsRequired();

            entity.HasOne(q => q.Module)
                  .WithMany(m => m.Quizzes)
                  .HasForeignKey(q => q.ModuleId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasOne(q => q.Quiz)
                  .WithMany(quiz => quiz.Questions)
                  .HasForeignKey(q => q.QuizId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<QuizOption>(entity =>
        {
            entity.HasOne(o => o.Question)
                  .WithMany(q => q.Options)
                  .HasForeignKey(o => o.QuestionId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<QuizAttempt>(entity =>
        {
            entity.HasOne(a => a.User)
                  .WithMany(u => u.QuizAttempts)
                  .HasForeignKey(a => a.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Quiz)
                  .WithMany(q => q.QuizAttempts)
                  .HasForeignKey(a => a.QuizId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<QuizAnswer>(entity =>
        {
            entity.HasOne(a => a.QuizAttempt)
                  .WithMany(qa => qa.Answers)
                  .HasForeignKey(a => a.QuizAttemptId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(a => a.Question)
                  .WithMany(q => q.QuizAnswers)
                  .HasForeignKey(a => a.QuestionId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.SelectedOption)
                  .WithMany()
                  .HasForeignKey(a => a.SelectedOptionId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigureAssignments(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.Property(a => a.Title).HasMaxLength(200).IsRequired();

            entity.HasOne(a => a.Module)
                  .WithMany(m => m.Assignments)
                  .HasForeignKey(a => a.ModuleId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<AssignmentSubmission>(entity =>
        {
            entity.HasOne(s => s.Assignment)
                  .WithMany(a => a.Submissions)
                  .HasForeignKey(s => s.AssignmentId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(s => s.User)
                  .WithMany(u => u.AssignmentSubmissions)
                  .HasForeignKey(s => s.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigureGoalsAndAchievements(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Goal>(entity =>
        {
            entity.Property(g => g.Title).HasMaxLength(200).IsRequired();

            entity.HasOne(g => g.User)
                  .WithMany(u => u.Goals)
                  .HasForeignKey(g => g.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.LearningPath)
                  .WithMany()
                  .HasForeignKey(g => g.LearningPathId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Skill)
                  .WithMany()
                  .HasForeignKey(g => g.SkillId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.Property(a => a.Title).HasMaxLength(150).IsRequired();
        });

        modelBuilder.Entity<UserAchievement>(entity =>
        {
            entity.HasOne(ua => ua.User)
                  .WithMany(u => u.UserAchievements)
                  .HasForeignKey(ua => ua.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ua => ua.Achievement)
                  .WithMany(a => a.UserAchievements)
                  .HasForeignKey(ua => ua.AchievementId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigureProgressTracking(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserSkill>(entity =>
        {
            entity.HasOne(us => us.User)
                  .WithMany(u => u.UserSkills)
                  .HasForeignKey(us => us.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(us => us.Skill)
                  .WithMany(s => s.UserSkills)
                  .HasForeignKey(us => us.SkillId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<UserLearningPath>(entity =>
        {
            entity.HasOne(ulp => ulp.User)
                  .WithMany(u => u.UserLearningPaths)
                  .HasForeignKey(ulp => ulp.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ulp => ulp.LearningPath)
                  .WithMany(lp => lp.UserLearningPaths)
                  .HasForeignKey(ulp => ulp.LearningPathId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<LessonProgress>(entity =>
        {
            entity.HasOne(lp => lp.User)
                  .WithMany(u => u.LessonProgresses)
                  .HasForeignKey(lp => lp.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(lp => lp.Lesson)
                  .WithMany(l => l.LessonProgresses)
                  .HasForeignKey(lp => lp.LessonId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
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
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
