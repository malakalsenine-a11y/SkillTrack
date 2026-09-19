namespace SkillTrack.API.DTOs;

/// <summary>Full shape for the Learning Path Details page - includes ordered modules.</summary>
public class LearningPathDetailDto : LearningPathDto
{
    public List<ModuleDto> Modules { get; set; } = new();
}
