namespace SkillTrack.API.DTOs;

/// <summary>The full admin dashboard payload (spec section 17).</summary>
public class AdminDashboardDto
{
    public int TotalUsers { get; set; }

    public int ActiveUsers { get; set; }

    public int TotalLearningPaths { get; set; }

    public int TotalSkills { get; set; }

    public int TotalAssignments { get; set; }

    public double AverageQuizScore { get; set; }

    public List<PopularItemDto> MostPopularSkills { get; set; } = new();

    public List<PopularItemDto> MostPopularLearningPaths { get; set; } = new();
}
