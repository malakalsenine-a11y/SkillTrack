using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/modules")]
public class ModulesController : BaseApiController
{
    private readonly IModuleService _moduleService;

    public ModulesController(IModuleService moduleService)
    {
        _moduleService = moduleService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ModuleDetailDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var module = await _moduleService.GetByIdAsync(id, cancellationToken);
        return module is null ? NotFound() : Ok(module);
    }

    [HttpGet("learning-path/{learningPathId:guid}")]
    public async Task<ActionResult<IReadOnlyList<ModuleDto>>> GetByLearningPathId(Guid learningPathId, CancellationToken cancellationToken)
    {
        var modules = await _moduleService.GetByLearningPathIdAsync(learningPathId, cancellationToken);
        return Ok(modules);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ModuleDto>> Create(CreateModuleRequestDto request, CancellationToken cancellationToken)
    {
        var module = await _moduleService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = module.Id }, module);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ModuleDto>> Update(Guid id, UpdateModuleRequestDto request, CancellationToken cancellationToken)
    {
        var module = await _moduleService.UpdateAsync(id, request, cancellationToken);
        return Ok(module);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _moduleService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
