using Microsoft.AspNetCore.Identity;
using SkillTrack.API.Models;

namespace SkillTrack.API.Services;

public class PasswordHasherService : IPasswordHasherService
{
    // PasswordHasher<TUser>'s default implementation never actually reads the
    // "user" argument - it's only there for extensibility (e.g. per-user salt
    // schemes), so passing null! for it is safe and is the standard pattern.
    private readonly PasswordHasher<User> _hasher = new();

    public string HashPassword(string password)
        => _hasher.HashPassword(null!, password);

    public bool VerifyPassword(string password, string passwordHash)
    {
        var result = _hasher.VerifyHashedPassword(null!, passwordHash, password);
        return result is PasswordVerificationResult.Success
            or PasswordVerificationResult.SuccessRehashNeeded;
    }
}