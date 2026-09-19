using SkillTrack.API.DTOs;

namespace SkillTrack.API.Services;

public interface IQuizService
{
    /// <summary>What a learner sees when starting the quiz - correct answers hidden.</summary>
    Task<QuizForAttemptDto?> GetForAttemptAsync(Guid quizId, CancellationToken cancellationToken = default);

    /// <summary>Admin/edit view - includes correct answers.</summary>
    Task<QuizDetailDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<QuizDto>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default);

    Task<QuizDto> CreateAsync(CreateQuizRequestDto request, CancellationToken cancellationToken = default);

    Task<QuizDto> UpdateAsync(Guid id, UpdateQuizRequestDto request, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<QuestionDto> AddQuestionAsync(CreateQuestionRequestDto request, CancellationToken cancellationToken = default);

    Task<QuestionDto> UpdateQuestionAsync(Guid questionId, UpdateQuestionRequestDto request, CancellationToken cancellationToken = default);

    Task DeleteQuestionAsync(Guid questionId, CancellationToken cancellationToken = default);

    /// <summary>Validates answers, calculates score/percentage, determines pass/fail,
    /// stores the attempt + answers, and updates progress (spec section 8, steps 1-8).</summary>
    Task<QuizAttemptResultDto> SubmitAttemptAsync(Guid userId, SubmitQuizAttemptRequestDto request, CancellationToken cancellationToken = default);

    /// <summary>Attempt history, newest first (spec section 9).</summary>
    Task<IReadOnlyList<QuizAttemptSummaryDto>> GetAttemptHistoryAsync(Guid userId, Guid quizId, CancellationToken cancellationToken = default);

    Task<QuizAttemptResultDto?> GetAttemptResultAsync(Guid attemptId, CancellationToken cancellationToken = default);
}
