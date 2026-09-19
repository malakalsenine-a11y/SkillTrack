namespace SkillTrack.API.DTOs;

/// <summary>Summary shape - one row within a LearningPathDetailDto.</summary>
public class ModuleDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int OrderIndex { get; set; }

    public Guid LearningPathId { get; set; }

    public int LessonCount { get; set; }

    public bool HasQuiz { get; set; }

    public bool HasAssignment { get; set; }
}
