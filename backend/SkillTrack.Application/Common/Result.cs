namespace SkillTrack.Application.Common;

/// <summary>
/// Represents the outcome of a service operation without relying on exceptions
/// for expected failure paths (validation errors, not-found, etc).
/// Controllers translate this into the appropriate HTTP status code.
/// </summary>
public class Result
{
    public bool Succeeded { get; protected set; }
    public IReadOnlyList<string> Errors { get; protected set; } = Array.Empty<string>();

    public static Result Success() => new() { Succeeded = true };

    public static Result Failure(params string[] errors) =>
        new() { Succeeded = false, Errors = errors };
}

/// <summary>
/// A <see cref="Result"/> that also carries a return value when successful.
/// </summary>
public class Result<T> : Result
{
    public T? Value { get; private set; }

    public static Result<T> Success(T value) =>
        new() { Succeeded = true, Value = value };

    public static new Result<T> Failure(params string[] errors) =>
        new() { Succeeded = false, Errors = errors };
}
