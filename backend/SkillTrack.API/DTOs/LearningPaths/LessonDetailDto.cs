namespace SkillTrack.API.DTOs;

/// <summary>Full lesson content, including its resources - what a learner sees
/// when they open a lesson to read/study it.</summary>
public class LessonDetailDto : LessonDto
{
    public string Content { get; set; } = string.Empty;

    public List<ResourceDto> Resources { get; set; } = new();
}
