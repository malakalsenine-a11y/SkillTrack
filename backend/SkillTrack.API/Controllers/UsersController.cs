using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs;
using SkillTrack.API.Services;

namespace SkillTrack.API.Controllers;

[Route("api/users")]
[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> GetMyProfile(CancellationToken cancellationToken)
    {
        var user = await _userService.GetByIdAsync(GetCurrentUserId(), cancellationToken);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPut("me")]
    public async Task<ActionResult<UserDto>> UpdateMyProfile(UpdateProfileRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userService.UpdateProfileAsync(GetCurrentUserId(), request, cancellationToken);
            return Ok(user);
        }
        catch (KeyNotFoundException ex) { return NotFound(new { message = ex.Message }); }
    }

    [HttpPut("me/password")]
    public async Task<IActionResult> ChangeMyPassword(ChangePasswordRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            await _userService.ChangePasswordAsync(GetCurrentUserId(), request, cancellationToken);
            return NoContent();
        }
        catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        catch (KeyNotFoundException ex) { return NotFound(new { message = ex.Message }); }
        catch (UnauthorizedAccessException ex) { return Unauthorized(new { message = ex.Message }); }
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<PagedResult<AdminUserListItemDto>>> GetAllUsers(
        [FromQuery] string? searchTerm, [FromQuery] int page = 1, [FromQuery] int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var result = await _userService.GetAllUsersAsync(searchTerm, page, pageSize, cancellationToken);
        return Ok(result);
    }

    [HttpPut("{id:guid}/role")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateUserRole(Guid id, UpdateUserRoleRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            await _userService.UpdateUserRoleAsync(id, request, cancellationToken);
            return NoContent();
        }
        catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        catch (KeyNotFoundException ex) { return NotFound(new { message = ex.Message }); }
    }

    [HttpPut("{id:guid}/active")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SetUserActiveStatus(Guid id, SetUserActiveRequestDto request, CancellationToken cancellationToken)
    {
        try
        {
            await _userService.SetUserActiveStatusAsync(id, request, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException ex) { return NotFound(new { message = ex.Message }); }
    }
}