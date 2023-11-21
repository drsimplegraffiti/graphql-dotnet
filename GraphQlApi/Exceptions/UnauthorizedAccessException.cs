using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlApi.Exceptions
{
    public class UnauthorizedAccessException: Exception
    {
        public int StatusCode { get; set; }
        public UnauthorizedAccessException(string message, Exception innerException, int statusCode) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}