namespace SkillTrack.API.DTOs;

/// <summary>The full "meaningful learning indicators" breakdown from spec section 2/7
/// - deliberately NOT just a single percentage.</summary>
public class OverallProgressDto
{
    public double OverallProgressPercentage { get; set; }

    public int LessonsCompleted { get; set; }

    public int LessonsRemaining { get; set; }

    public int QuizAttemptsCount { get; set; }

    public double AverageQuizScore { get; set; }

    public int AssignmentsSubmitted { get; set; }

    public int SkillsCompleted { get; set; }

    public int SkillsInProgress { get; set; }

    public int ActiveLearningPaths { get; set; }

    public int GoalsCompleted { get; set; }

    public List<WeakStrongAreaDto> WeakAreas { get; set; } = new();

    public List<WeakStrongAreaDto> StrongAreas { get; set; } = new();
}
