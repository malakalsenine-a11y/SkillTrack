using SkillTrack.API.DTOs;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class GoalService : IGoalService
{
    private readonly IGoalRepository _goalRepository;

    public GoalService(IGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }

    public Task<IReadOnlyList<GoalDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GoalDto?> GetByIdAsync(Guid id, Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GoalDto> CreateAsync(Guid userId, CreateGoalRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GoalDto> UpdateAsync(Guid id, Guid userId, UpdateGoalRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
