namespace SimpleBlog.Features
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
    public class OperationResult<T> : OperationResult
    {
        public T? data { get; set; }
    }
}
