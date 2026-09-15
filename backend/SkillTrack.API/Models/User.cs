using SkillTrack.API.Enums;

namespace SkillTrack.API.Models;

/// <summary>
/// A registered account in SkillTrack — either a Learner or an Admin.
/// </summary>
public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    /// <summary>Used as the login identifier. Must be unique — enforced in
    /// the EF Core entity configuration, not here (Domain has no persistence concerns).</summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>Hashed password only. The Domain layer never sees or stores plaintext
    /// passwords — hashing happens in Infrastructure/Application's auth service.</summary>
    public string PasswordHash { get; set; } = string.Empty;

    public UserRole Role { get; set; } = UserRole.Learner;

    public string? ProfilePictureUrl { get; set; }

    public string? Bio { get; set; }

    /// <summary>Lets an admin disable an account without deleting it (and its history).</summary>
    public bool IsActive { get; set; } = true;

    public string FullName => $"{FirstName} {LastName}";

    public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
    public ICollection<UserLearningPath> UserLearningPaths { get; set; } = new List<UserLearningPath>();
    public ICollection<LessonProgress> LessonProgresses { get; set; } = new List<LessonProgress>();
    public ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
    public ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = new List<AssignmentSubmission>();
    public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    public ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
}
