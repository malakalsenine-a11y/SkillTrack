using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/quizzes")]
public class QuizzesController : BaseApiController
{
    private readonly IQuizService _quizService;

    public QuizzesController(IQuizService quizService)
    {
        _quizService = quizService;
    }

    /// <summary>What a learner sees when starting the quiz - correct answers hidden.</summary>
    [HttpGet("{id:guid}/attempt")]
    [Authorize]
    public async Task<ActionResult<QuizForAttemptDto>> GetForAttempt(Guid id, CancellationToken cancellationToken)
    {
        var quiz = await _quizService.GetForAttemptAsync(id, cancellationToken);
        return quiz is null ? NotFound() : Ok(quiz);
    }

    /// <summary>Admin/edit view - includes correct answers.</summary>
    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<QuizDetailDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var quiz = await _quizService.GetByIdAsync(id, cancellationToken);
        return quiz is null ? NotFound() : Ok(quiz);
    }

    [HttpGet("module/{moduleId:guid}")]
    public async Task<ActionResult<IReadOnlyList<QuizDto>>> GetByModuleId(Guid moduleId, CancellationToken cancellationToken)
    {
        var quizzes = await _quizService.GetByModuleIdAsync(moduleId, cancellationToken);
        return Ok(quizzes);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<QuizDto>> Create(CreateQuizRequestDto request, CancellationToken cancellationToken)
    {
        var quiz = await _quizService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = quiz.Id }, quiz);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<QuizDto>> Update(Guid id, UpdateQuizRequestDto request, CancellationToken cancellationToken)
    {
        var quiz = await _quizService.UpdateAsync(id, request, cancellationToken);
        return Ok(quiz);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _quizService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPost("questions")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<QuestionDto>> AddQuestion(CreateQuestionRequestDto request, CancellationToken cancellationToken)
    {
        var question = await _quizService.AddQuestionAsync(request, cancellationToken);
        return Ok(question);
    }

    [HttpPut("questions/{questionId:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<QuestionDto>> UpdateQuestion(Guid questionId, UpdateQuestionRequestDto request, CancellationToken cancellationToken)
    {
        var question = await _quizService.UpdateQuestionAsync(questionId, request, cancellationToken);
        return Ok(question);
    }

    [HttpDelete("questions/{questionId:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteQuestion(Guid questionId, CancellationToken cancellationToken)
    {
        await _quizService.DeleteQuestionAsync(questionId, cancellationToken);
        return NoContent();
    }

    /// <summary>Submits an attempt - validates, grades, stores it, and returns the
    /// result (spec section 8, steps 1-8) in one call.</summary>
    [HttpPost("{id:guid}/attempts")]
    [Authorize]
    public async Task<ActionResult<QuizAttemptResultDto>> SubmitAttempt(Guid id, SubmitQuizAttemptRequestDto request, CancellationToken cancellationToken)
    {
        request.QuizId = id;
        var result = await _quizService.SubmitAttemptAsync(GetCurrentUserId(), request, cancellationToken);
        return Ok(result);
    }

    /// <summary>The calling user's attempt history for this quiz (spec section 9).</summary>
    [HttpGet("{id:guid}/attempts")]
    [Authorize]
    public async Task<ActionResult<IReadOnlyList<QuizAttemptSummaryDto>>> GetAttemptHistory(Guid id, CancellationToken cancellationToken)
    {
        var history = await _quizService.GetAttemptHistoryAsync(GetCurrentUserId(), id, cancellationToken);
        return Ok(history);
    }

    [HttpGet("attempts/{attemptId:guid}")]
    [Authorize]
    public async Task<ActionResult<QuizAttemptResultDto>> GetAttemptResult(Guid attemptId, CancellationToken cancellationToken)
    {
        var result = await _quizService.GetAttemptResultAsync(attemptId, cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }
}
