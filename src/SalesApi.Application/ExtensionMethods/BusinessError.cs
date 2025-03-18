using System.Net;
using FluentResults;

namespace SalesApi.Application.ExtensionMethods
{
    public class BusinessError : Error
    {
        public BusinessError(HttpStatusCode httpStatusCode, string error, string detail)
            : base(detail)
        {
            Metadata.Add(nameof(HttpStatusCode), httpStatusCode);
            Metadata.Add("error", error);
        }
    }
}
