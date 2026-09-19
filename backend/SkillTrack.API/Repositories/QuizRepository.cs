using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class QuizRepository : GenericRepository<Quiz>, IQuizRepository
{
    public QuizRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<Quiz?> GetByIdWithQuestionsAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<Quiz?> GetByIdForAttemptAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<Quiz>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> GetTotalScoreAsync(Guid quizId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
