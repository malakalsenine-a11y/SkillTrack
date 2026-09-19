using SkillTrack.API.DTOs;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class ResourceService : IResourceService
{
    private readonly IResourceRepository _resourceRepository;

    public ResourceService(IResourceRepository resourceRepository)
    {
        _resourceRepository = resourceRepository;
    }

    public Task<IReadOnlyList<ResourceDto>> GetByLessonIdAsync(Guid lessonId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ResourceDto> CreateAsync(CreateResourceRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ResourceDto> UpdateAsync(Guid id, UpdateResourceRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
