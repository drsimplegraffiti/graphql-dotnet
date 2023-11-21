using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlApi.Exceptions
{
    public class NotImplementedException: Exception
    {
        public int StatusCode { get; set; }
        public NotImplementedException(string message, Exception innerException, int statusCode) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}