using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
{
    public QuestionRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<Question>> GetByQuizIdAsync(Guid quizId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<Question?> GetByIdWithOptionsAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<Question>> GetByQuizIdWithOptionsAsync(Guid quizId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountByQuizIdAsync(Guid quizId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
