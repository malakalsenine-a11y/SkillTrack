using SkillTrack.API.DTOs;

namespace SkillTrack.API.Services;

public interface IResourceService
{
    Task<IReadOnlyList<ResourceDto>> GetByLessonIdAsync(Guid lessonId, CancellationToken cancellationToken = default);

    Task<ResourceDto> CreateAsync(CreateResourceRequestDto request, CancellationToken cancellationToken = default);

    Task<ResourceDto> UpdateAsync(Guid id, UpdateResourceRequestDto request, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
