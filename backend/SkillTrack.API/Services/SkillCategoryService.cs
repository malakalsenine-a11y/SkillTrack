using SkillTrack.API.DTOs;
using SkillTrack.API.Models;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class SkillCategoryService : ISkillCategoryService
{
    private readonly ISkillCategoryRepository _skillCategoryRepository;

    public SkillCategoryService(ISkillCategoryRepository skillCategoryRepository)
    {
        _skillCategoryRepository = skillCategoryRepository;
    }

    public async Task<IReadOnlyList<SkillCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _skillCategoryRepository.GetAllWithSkillsAsync(cancellationToken);
        return categories.Select(MapToDto).ToList();
    }

    public async Task<SkillCategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _skillCategoryRepository.GetByIdWithSkillsAsync(id, cancellationToken);
        return category is null ? null : MapToDto(category);
    }

    public async Task<SkillCategoryDto> CreateAsync(CreateSkillCategoryRequestDto request, CancellationToken cancellationToken = default)
    {
        if (await _skillCategoryRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
            throw new InvalidOperationException("A skill category with this name already exists.");

        var category = new SkillCategory { Name = request.Name.Trim(), Description = request.Description };

        await _skillCategoryRepository.AddAsync(category, cancellationToken);
        await _skillCategoryRepository.SaveChangesAsync(cancellationToken);

        return MapToDto(category);
    }

    public async Task<SkillCategoryDto> UpdateAsync(Guid id, UpdateSkillCategoryRequestDto request, CancellationToken cancellationToken = default)
    {
        // Loaded WITH skills so the returned SkillCount is accurate - a plain
        // GetByIdAsync would leave Skills as an empty (unloaded) collection.
        var category = await _skillCategoryRepository.GetByIdWithSkillsAsync(id, cancellationToken)
            ?? throw new KeyNotFoundException("Skill category not found.");

        if (await _skillCategoryRepository.ExistsByNameAsync(request.Name, id, cancellationToken))
            throw new InvalidOperationException("A skill category with this name already exists.");

        category.Name = request.Name.Trim();
        category.Description = request.Description;

        _skillCategoryRepository.Update(category);
        await _skillCategoryRepository.SaveChangesAsync(cancellationToken);

        return MapToDto(category);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _skillCategoryRepository.GetByIdWithSkillsAsync(id, cancellationToken)
            ?? throw new KeyNotFoundException("Skill category not found.");

        // Skill.SkillCategoryId uses DeleteBehavior.Restrict, so the DB would
        // reject this anyway if skills exist - this just gives a clean error first.
        if (category.Skills.Count > 0)
            throw new InvalidOperationException("Cannot delete a category that still has skills. Move or delete its skills first.");

        _skillCategoryRepository.Remove(category);
        await _skillCategoryRepository.SaveChangesAsync(cancellationToken);
    }

    private static SkillCategoryDto MapToDto(SkillCategory category) => new()
    {
        Id = category.Id,
        Name = category.Name,
        Description = category.Description,
        SkillCount = category.Skills.Count
    };
}