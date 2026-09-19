using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class QuizAttemptRepository : GenericRepository<QuizAttempt>, IQuizAttemptRepository
{
    public QuizAttemptRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<QuizAttempt>> GetByUserAndQuizAsync(Guid userId, Guid quizId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<QuizAttempt>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<QuizAttempt?> GetByIdWithAnswersAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<QuizAttempt?> GetBestAttemptAsync(Guid userId, Guid quizId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<QuizAttempt?> GetLatestAttemptAsync(Guid userId, Guid quizId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountAttemptsAsync(Guid userId, Guid quizId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<bool> HasPassedAsync(Guid userId, Guid quizId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<double> GetAverageScoreByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<double> GetPlatformAverageScoreAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<QuizAttempt>> GetBestAttemptsByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
