namespace InventoryManagement.Common
{
    public class ApiBaseResponse<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }

        public static ApiBaseResponse<T> Success(T data)
        {
            return new ApiBaseResponse<T>() { Data = data, IsSuccess = true };
        }

        public static ApiBaseResponse<T> Success()
        {
            return new ApiBaseResponse<T>() { IsSuccess = true };
        }

        public static ApiBaseResponse<T> Failed(T data)
        {
            return new ApiBaseResponse<T>() { Data = data, IsSuccess = false };
        }

        public ApiBaseResponse()
        {
        }
    }
}
