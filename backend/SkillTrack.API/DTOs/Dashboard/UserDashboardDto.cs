namespace SkillTrack.API.DTOs;

/// <summary>The full learner dashboard payload (spec section 15) - one call
/// returns everything the dashboard page needs to render.</summary>
public class UserDashboardDto
{
    public double OverallProgressPercentage { get; set; }

    public int ActiveLearningPaths { get; set; }

    public int CompletedLessons { get; set; }

    public int CompletedQuizzes { get; set; }

    public double AverageQuizScore { get; set; }

    public int CompletedAssignments { get; set; }

    public int CompletedGoals { get; set; }

    public int CurrentStreakDays { get; set; }

    public LessonDto? RecommendedNextLesson { get; set; }

    public List<RecentActivityDto> RecentActivity { get; set; } = new();

    public List<SkillProgressDto> SkillProgress { get; set; } = new();

    public List<WeakStrongAreaDto> StrongAreas { get; set; } = new();

    public List<WeakStrongAreaDto> WeakAreas { get; set; } = new();

    public List<GoalDto> Goals { get; set; } = new();

    public List<UserAchievementDto> Achievements { get; set; } = new();
}
