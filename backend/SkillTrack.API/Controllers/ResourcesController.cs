using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/resources")]
public class ResourcesController : BaseApiController
{
    private readonly IResourceService _resourceService;

    public ResourcesController(IResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    [HttpGet("lesson/{lessonId:guid}")]
    public async Task<ActionResult<IReadOnlyList<ResourceDto>>> GetByLessonId(Guid lessonId, CancellationToken cancellationToken)
    {
        var resources = await _resourceService.GetByLessonIdAsync(lessonId, cancellationToken);
        return Ok(resources);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ResourceDto>> Create(CreateResourceRequestDto request, CancellationToken cancellationToken)
    {
        var resource = await _resourceService.CreateAsync(request, cancellationToken);
        return Ok(resource);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ResourceDto>> Update(Guid id, UpdateResourceRequestDto request, CancellationToken cancellationToken)
    {
        var resource = await _resourceService.UpdateAsync(id, request, cancellationToken);
        return Ok(resource);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _resourceService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
