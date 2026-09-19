using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface ISkillCategoryRepository : IGenericRepository<SkillCategory>
{
    Task<IReadOnlyList<SkillCategory>> GetAllWithSkillsAsync(CancellationToken cancellationToken = default);

    Task<SkillCategory?> GetByIdWithSkillsAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>Duplicate-name check. Pass excludeId when updating so the record
    /// being edited doesn't count as a conflict with itself.</summary>
    Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null, CancellationToken cancellationToken = default);
}
