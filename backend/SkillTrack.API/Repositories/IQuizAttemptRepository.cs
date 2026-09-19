using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IQuizAttemptRepository : IGenericRepository<QuizAttempt>
{
    /// <summary>Full attempt history for one user on one quiz (spec section 9 -
    /// history is preserved, newest first).</summary>
    Task<IReadOnlyList<QuizAttempt>> GetByUserAndQuizAsync(Guid userId, Guid quizId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<QuizAttempt>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Attempt + its answers (+ question and selected option) for the results page.</summary>
    Task<QuizAttempt?> GetByIdWithAnswersAsync(Guid id, CancellationToken cancellationToken = default);

    Task<QuizAttempt?> GetBestAttemptAsync(Guid userId, Guid quizId, CancellationToken cancellationToken = default);

    Task<QuizAttempt?> GetLatestAttemptAsync(Guid userId, Guid quizId, CancellationToken cancellationToken = default);

    Task<int> CountAttemptsAsync(Guid userId, Guid quizId, CancellationToken cancellationToken = default);

    /// <summary>Whether the user has ever passed this quiz - feeds progress calculation.</summary>
    Task<bool> HasPassedAsync(Guid userId, Guid quizId, CancellationToken cancellationToken = default);

    /// <summary>Average percentage across all of this user's attempts (dashboard).</summary>
    Task<double> GetAverageScoreByUserAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Platform-wide average quiz score (admin dashboard).</summary>
    Task<double> GetPlatformAverageScoreAsync(CancellationToken cancellationToken = default);

    /// <summary>Per-quiz average for this user - used to derive weak/strong areas (spec section 16).</summary>
    Task<IReadOnlyList<QuizAttempt>> GetBestAttemptsByUserAsync(Guid userId, CancellationToken cancellationToken = default);
}
