namespace SalesApi.Application.DTO.Response
{
    public class BaseErrorResponse : IResponse
    {
        public BaseErrorResponse(string type, string error, string detail)
        {
            this.type = type;
            this.error = error;
            this.detail = detail;
        }

        public string type { get; set; }
        public string error { get; set; }
        public string detail { get; set; }
    }
}
