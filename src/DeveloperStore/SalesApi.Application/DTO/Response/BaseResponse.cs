namespace SalesApi.Application.DTO.Response
{
    public class BaseResponse<T> : IResponse
    {
        public BaseResponse(T data, string status, string message)
        {
            Data = data;
            Status = status;
            Message = message;
        }

        public T Data { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}

