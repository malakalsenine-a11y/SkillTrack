using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IQuizRepository : IGenericRepository<Quiz>
{
    /// <summary>Quiz + questions + each question's options. Used when a learner
    /// opens a quiz and when an admin edits it.</summary>
    Task<Quiz?> GetByIdWithQuestionsAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>Same as above but WITHOUT revealing QuizOption.IsCorrect - for
    /// serving the quiz to a learner. (Filtering happens in the service/DTO layer;
    /// this exists so the service can choose the safe load explicitly.)</summary>
    Task<Quiz?> GetByIdForAttemptAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Quiz>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default);

    /// <summary>Sum of all question scores - the denominator when grading an attempt.</summary>
    Task<int> GetTotalScoreAsync(Guid quizId, CancellationToken cancellationToken = default);

    Task<int> CountByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default);
}
