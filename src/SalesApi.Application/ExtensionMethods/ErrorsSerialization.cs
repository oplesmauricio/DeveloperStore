using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;

namespace SalesApi.Application.ExtensionMethods
{
    public static class ErrorsSerialization
    {
        public static StringBuilder Serialization(this List<IError> errors)
        {
            var stringBuilder = new StringBuilder();
            foreach (var error in errors)
                stringBuilder.AppendLine(error.Message.ToString());

            return stringBuilder;
        }
    }
}
