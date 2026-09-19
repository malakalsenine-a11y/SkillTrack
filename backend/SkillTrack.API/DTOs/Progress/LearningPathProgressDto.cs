using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs;

/// <summary>Detailed per-path progress breakdown (spec section 7: lessons 8/10,
/// quiz 4/5, assignments 1/2, overall 72%).</summary>
public class LearningPathProgressDto
{
    public Guid LearningPathId { get; set; }

    public string LearningPathTitle { get; set; } = string.Empty;

    public double ProgressPercentage { get; set; }

    public ProgressStatus Status { get; set; }

    public int LessonsCompleted { get; set; }

    public int TotalLessons { get; set; }

    public int QuizzesCompleted { get; set; }

    public int TotalQuizzes { get; set; }

    public int AssignmentsCompleted { get; set; }

    public int TotalAssignments { get; set; }

    public DateTime EnrolledAt { get; set; }

    public DateTime? CompletedAt { get; set; }
}
