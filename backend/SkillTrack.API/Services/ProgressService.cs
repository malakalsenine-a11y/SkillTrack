using SkillTrack.API.DTOs;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class ProgressService : IProgressService
{
    private readonly ILessonProgressRepository _lessonProgressRepository;
    private readonly IQuizAttemptRepository _quizAttemptRepository;
    private readonly IAssignmentSubmissionRepository _assignmentSubmissionRepository;
    private readonly IUserLearningPathRepository _userLearningPathRepository;
    private readonly IUserSkillRepository _userSkillRepository;
    private readonly IGoalRepository _goalRepository;

    public ProgressService(
        ILessonProgressRepository lessonProgressRepository,
        IQuizAttemptRepository quizAttemptRepository,
        IAssignmentSubmissionRepository assignmentSubmissionRepository,
        IUserLearningPathRepository userLearningPathRepository,
        IUserSkillRepository userSkillRepository,
        IGoalRepository goalRepository)
    {
        _lessonProgressRepository = lessonProgressRepository;
        _quizAttemptRepository = quizAttemptRepository;
        _assignmentSubmissionRepository = assignmentSubmissionRepository;
        _userLearningPathRepository = userLearningPathRepository;
        _userSkillRepository = userSkillRepository;
        _goalRepository = goalRepository;
    }

    public Task<OverallProgressDto> GetOverallProgressAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<LearningPathProgressDto> GetLearningPathProgressAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<SkillProgressDto>> GetSkillProgressAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task RecalculateLearningPathProgressAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task RecalculateSkillProgressAsync(Guid userId, Guid skillId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
