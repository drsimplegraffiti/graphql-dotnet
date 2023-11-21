using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlApi.Exceptions
{
    public class NotFoundException: Exception
    {
        public int StatusCode { get; set; }
        public NotFoundException(string message, Exception innerException, int statusCode) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}