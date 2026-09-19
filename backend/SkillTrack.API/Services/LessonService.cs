using SkillTrack.API.DTOs;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class LessonService : ILessonService
{
    private readonly ILessonRepository _lessonRepository;
    private readonly ILessonProgressRepository _lessonProgressRepository;

    public LessonService(
        ILessonRepository lessonRepository,
        ILessonProgressRepository lessonProgressRepository)
    {
        _lessonRepository = lessonRepository;
        _lessonProgressRepository = lessonProgressRepository;
    }

    public Task<LessonDetailDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<LessonDto>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<LessonDto> CreateAsync(CreateLessonRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<LessonDto> UpdateAsync(Guid id, UpdateLessonRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task MarkCompleteAsync(Guid userId, Guid lessonId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
