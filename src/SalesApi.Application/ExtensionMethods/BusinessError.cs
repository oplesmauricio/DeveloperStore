using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using SalesApi.Application.DTO.Response;

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
