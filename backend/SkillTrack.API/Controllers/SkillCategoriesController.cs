using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/skill-categories")]
public class SkillCategoriesController : BaseApiController
{
    private readonly ISkillCategoryService _skillCategoryService;

    public SkillCategoriesController(ISkillCategoryService skillCategoryService)
    {
        _skillCategoryService = skillCategoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<SkillCategoryDto>>> GetAll(CancellationToken cancellationToken)
    {
        var categories = await _skillCategoryService.GetAllAsync(cancellationToken);
        return Ok(categories);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SkillCategoryDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var category = await _skillCategoryService.GetByIdAsync(id, cancellationToken);
        return category is null ? NotFound() : Ok(category);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<SkillCategoryDto>> Create(CreateSkillCategoryRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _skillCategoryService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }
        catch (InvalidOperationException ex) { return Conflict(new { message = ex.Message }); }
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<SkillCategoryDto>> Update(Guid id, UpdateSkillCategoryRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _skillCategoryService.UpdateAsync(id, request, cancellationToken);
            return Ok(category);
        }
        catch (KeyNotFoundException ex) { return NotFound(new { message = ex.Message }); }
        catch (InvalidOperationException ex) { return Conflict(new { message = ex.Message }); }
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _skillCategoryService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException ex) { return NotFound(new { message = ex.Message }); }
        catch (InvalidOperationException ex) { return Conflict(new { message = ex.Message }); }
    }
}