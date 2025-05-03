namespace Common.Infrastructure
{
    public class ApiResponse<T>
    {
        public string State { get; set; }  // "SUCCESS" or "ERROR"
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static ApiResponse<T> Success(T data, string? message = null)
        {
            return new ApiResponse<T>
            {
                State = "SUCCESS",
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> Error(string message)
        {
            return new ApiResponse<T>
            {
                State = "ERROR",
                Message = message,
                Data = default
            };
        }
    }

}
