using Microsoft.Extensions.Configuration;
using SkillTrack.API.Models;

namespace SkillTrack.API.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
        => throw new NotImplementedException();

    public DateTime GetTokenExpirationUtc()
        => throw new NotImplementedException();
}
