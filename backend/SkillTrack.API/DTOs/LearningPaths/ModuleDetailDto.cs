namespace SkillTrack.API.DTOs;

/// <summary>Full module content - what a learner sees when they open a module.</summary>
public class ModuleDetailDto : ModuleDto
{
    public List<LessonDto> Lessons { get; set; } = new();

    public List<QuizDto> Quizzes { get; set; } = new();

    public List<AssignmentDto> Assignments { get; set; } = new();
}
