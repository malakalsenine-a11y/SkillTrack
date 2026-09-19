using SkillTrack.API.DTOs;

namespace SkillTrack.API.Services;

/// <summary>
/// Turns raw activity rows (LessonProgress, QuizAttempt, AssignmentSubmission, ...)
/// into the "meaningful learning indicators" the spec calls for (section 7) - never
/// just a single percentage. Consumed by DashboardService and by the
/// GET /api/progress* endpoints directly.
/// </summary>
public interface IProgressService
{
    Task<OverallProgressDto> GetOverallProgressAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<LearningPathProgressDto> GetLearningPathProgressAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<SkillProgressDto>> GetSkillProgressAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Recalculates and persists a UserLearningPath's ProgressPercentage/
    /// Status from current lesson/quiz/assignment completion - called after any
    /// activity that could move the needle (lesson completed, quiz passed, ...).</summary>
    Task RecalculateLearningPathProgressAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default);

    /// <summary>Recalculates a UserSkill's ProgressPercentage/Status from the
    /// progress of all learning paths under that skill.</summary>
    Task RecalculateSkillProgressAsync(Guid userId, Guid skillId, CancellationToken cancellationToken = default);
}
