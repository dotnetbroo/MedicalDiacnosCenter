namespace MedicalDiacnosCenter.Service.Configurations.Filters;

public class PaginationMetaData
{
    public int CurrentPage { get; set; }       // 1
    public int TotalPages { get; set; }         //10
    public int TotalCount { get; set; }         //15
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PaginationMetaData(int totalCount, PaginationParams @params)
    {
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)@params.PageSize);
        CurrentPage = @params.PageIndex;
    }
}
