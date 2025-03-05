namespace Ambev.DeveloperEvaluation.Application.Model
{
    public class PagnatedResult<T>
    {
        public T? Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
