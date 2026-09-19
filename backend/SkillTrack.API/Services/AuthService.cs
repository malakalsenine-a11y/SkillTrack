using SkillTrack.API.DTOs;
using SkillTrack.API.Models;
using SkillTrack.API.Repositories;

namespace SkillTrack.API.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasher;
    private readonly IJwtTokenService _jwtTokenService;

    // NOTE: this only calls the generic methods guaranteed by IGenericRepository<User>
    // (FindAsync, AddAsync, SaveChangesAsync). If IUserRepository doesn't already have
    // a dedicated GetByEmailAsync/ExistsByEmailAsync, consider adding one for a single
    // indexed lookup instead of FindAsync's full predicate scan.
    public AuthService(
        IUserRepository userRepository,
        IPasswordHasherService passwordHasher,
        IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
    }

    public Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<AuthResponseDto> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
