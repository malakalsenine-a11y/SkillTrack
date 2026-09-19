using SkillTrack.API.DTOs;

namespace SkillTrack.API.Services;

public interface ILessonService
{
    Task<LessonDetailDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<LessonDto>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default);

    Task<LessonDto> CreateAsync(CreateLessonRequestDto request, CancellationToken cancellationToken = default);

    Task<LessonDto> UpdateAsync(Guid id, UpdateLessonRequestDto request, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>Marks a lesson complete for a user (spec section 4.1 "Complete
    /// lessons") - creates/updates the LessonProgress row. Watching/opening a
    /// lesson is not the same as completing it (spec section 3), so this is an
    /// explicit action, not implied by GetByIdAsync.</summary>
    Task MarkCompleteAsync(Guid userId, Guid lessonId, CancellationToken cancellationToken = default);
}
