namespace SkillTrack.API.DTOs;

/// <summary>
/// Wraps a single page of results plus the metadata the frontend needs to render
/// pagination controls. Used by repositories that support search/filter/paging.
/// </summary>
public class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; set; } = new List<T>();

    public int TotalCount { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalPages => PageSize > 0 ? (int)Math.Ceiling(TotalCount / (double)PageSize) : 0;

    public bool HasPrevious => Page > 1;

    public bool HasNext => Page < TotalPages;
}