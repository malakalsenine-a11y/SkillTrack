using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IQuestionRepository : IGenericRepository<Question>
{
    Task<IReadOnlyList<Question>> GetByQuizIdAsync(Guid quizId, CancellationToken cancellationToken = default);

    /// <summary>Question + its options, including which option is correct. Used
    /// when grading a submitted attempt and when an admin edits the question.</summary>
    Task<Question?> GetByIdWithOptionsAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>All questions of a quiz with their options - loaded once when
    /// grading an attempt so we don't query per question.</summary>
    Task<IReadOnlyList<Question>> GetByQuizIdWithOptionsAsync(Guid quizId, CancellationToken cancellationToken = default);

    Task<int> CountByQuizIdAsync(Guid quizId, CancellationToken cancellationToken = default);
}
