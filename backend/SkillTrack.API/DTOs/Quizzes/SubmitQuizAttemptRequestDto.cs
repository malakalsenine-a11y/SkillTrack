namespace SkillTrack.API.DTOs;

public class SubmitQuizAttemptRequestDto
{
    public Guid QuizId { get; set; }

    public List<SubmitQuizAnswerRequestDto> Answers { get; set; } = new();
}
