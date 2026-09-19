using SkillTrack.API.DTOs;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class DashboardService : IDashboardService
{
    private readonly IProgressService _progressService;
    private readonly IUserLearningPathRepository _userLearningPathRepository;
    private readonly ILessonProgressRepository _lessonProgressRepository;
    private readonly IQuizAttemptRepository _quizAttemptRepository;
    private readonly IAssignmentSubmissionRepository _assignmentSubmissionRepository;
    private readonly IGoalRepository _goalRepository;
    private readonly IUserAchievementRepository _userAchievementRepository;
    private readonly ISkillRepository _skillRepository;
    private readonly ILearningPathRepository _learningPathRepository;

    public DashboardService(
        IProgressService progressService,
        IUserLearningPathRepository userLearningPathRepository,
        ILessonProgressRepository lessonProgressRepository,
        IQuizAttemptRepository quizAttemptRepository,
        IAssignmentSubmissionRepository assignmentSubmissionRepository,
        IGoalRepository goalRepository,
        IUserAchievementRepository userAchievementRepository,
        ISkillRepository skillRepository,
        ILearningPathRepository learningPathRepository)
    {
        _progressService = progressService;
        _userLearningPathRepository = userLearningPathRepository;
        _lessonProgressRepository = lessonProgressRepository;
        _quizAttemptRepository = quizAttemptRepository;
        _assignmentSubmissionRepository = assignmentSubmissionRepository;
        _goalRepository = goalRepository;
        _userAchievementRepository = userAchievementRepository;
        _skillRepository = skillRepository;
        _learningPathRepository = learningPathRepository;
    }

    public Task<UserDashboardDto> GetUserDashboardAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<AdminDashboardDto> GetAdminDashboardAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
