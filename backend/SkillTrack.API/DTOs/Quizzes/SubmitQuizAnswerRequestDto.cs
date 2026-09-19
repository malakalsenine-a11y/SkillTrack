namespace SkillTrack.API.DTOs;

public class SubmitQuizAnswerRequestDto
{
    public Guid QuestionId { get; set; }

    /// <summary>Null if the learner left this question unanswered.</summary>
    public Guid? SelectedOptionId { get; set; }
}
