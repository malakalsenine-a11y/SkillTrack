namespace SkillTrack.API.Services;

/// <summary>
/// Wraps password hashing so AuthService/UserService never touch a hashing
/// algorithm directly. Implementation (e.g. ASP.NET Core's PasswordHasher<T>,
/// or BCrypt) is chosen when this is implemented.
/// </summary>
public interface IPasswordHasherService
{
    string HashPassword(string password);

    bool VerifyPassword(string password, string passwordHash);
}
