namespace SkillTrack.API.DTOs;

/// <summary>OrderIndex is not supplied here - the service appends it as the next
/// position within the learning path (see IModuleRepository.GetNextOrderIndexAsync).</summary>
public class CreateModuleRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Guid LearningPathId { get; set; }
}
