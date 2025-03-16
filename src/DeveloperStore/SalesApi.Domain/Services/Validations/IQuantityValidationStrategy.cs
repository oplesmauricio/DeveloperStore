using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services.Validations
{
    public interface IQuantityValidationStrategy
    {
        bool IsValid(int quantity);
        string GetErrorMessage();
    }

}
