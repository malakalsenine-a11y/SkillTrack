using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/skills")]
public class SkillsController : BaseApiController
{
    private readonly ISkillService _skillService;

    public SkillsController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    /// <summary>Search/filter/paginate (spec section 18) - backend does the filtering, not the frontend.</summary>
    [HttpGet]
    public async Task<ActionResult<PagedResult<SkillDto>>> Search(
        [FromQuery] string? searchTerm,
        [FromQuery] Guid? categoryId,
        [FromQuery] DifficultyLevel? difficulty,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var result = await _skillService.SearchAsync(searchTerm, categoryId, difficulty, page, pageSize, cancellationToken);
        return Ok(result);
    }

    [HttpGet("popular")]
    public async Task<ActionResult<IReadOnlyList<SkillDto>>> GetMostPopular([FromQuery] int count = 5, CancellationToken cancellationToken = default)
    {
        var skills = await _skillService.GetMostPopularAsync(count, cancellationToken);
        return Ok(skills);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SkillDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var skill = await _skillService.GetByIdAsync(id, cancellationToken);
        return skill is null ? NotFound() : Ok(skill);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<SkillDto>> Create(CreateSkillRequestDto request, CancellationToken cancellationToken)
    {
        var skill = await _skillService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = skill.Id }, skill);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<SkillDto>> Update(Guid id, UpdateSkillRequestDto request, CancellationToken cancellationToken)
    {
        var skill = await _skillService.UpdateAsync(id, request, cancellationToken);
        return Ok(skill);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _skillService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
