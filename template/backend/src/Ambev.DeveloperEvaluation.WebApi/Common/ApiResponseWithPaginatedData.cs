namespace Ambev.DeveloperEvaluation.WebApi.Common;

public class ApiResponseWithPaginatedData<T> : ApiResponse
{
    public T? Data { get; set; }
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
