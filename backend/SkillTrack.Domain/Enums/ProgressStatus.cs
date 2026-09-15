namespace SkillTrack.Domain.Enums;

/// <summary>
/// Shared progress status used by UserSkill, UserLearningPath, and LessonProgress -
/// anywhere we track a user's advancement through something.
/// </summary>
public enum ProgressStatus
{
    NotStarted = 0,
    InProgress = 1,
    Completed = 2
}
