using SkillTrack.API.DTOs;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class QuizService : IQuizService
{
    private readonly IQuizRepository _quizRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuizAttemptRepository _quizAttemptRepository;

    public QuizService(
        IQuizRepository quizRepository,
        IQuestionRepository questionRepository,
        IQuizAttemptRepository quizAttemptRepository)
    {
        _quizRepository = quizRepository;
        _questionRepository = questionRepository;
        _quizAttemptRepository = quizAttemptRepository;
    }

    public Task<QuizForAttemptDto?> GetForAttemptAsync(Guid quizId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<QuizDetailDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<QuizDto>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<QuizDto> CreateAsync(CreateQuizRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<QuizDto> UpdateAsync(Guid id, UpdateQuizRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<QuestionDto> AddQuestionAsync(CreateQuestionRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<QuestionDto> UpdateQuestionAsync(Guid questionId, UpdateQuestionRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task DeleteQuestionAsync(Guid questionId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<QuizAttemptResultDto> SubmitAttemptAsync(Guid userId, SubmitQuizAttemptRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<QuizAttemptSummaryDto>> GetAttemptHistoryAsync(Guid userId, Guid quizId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<QuizAttemptResultDto?> GetAttemptResultAsync(Guid attemptId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
