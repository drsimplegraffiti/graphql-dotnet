using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlApi.Exceptions
{
    public class BadRequestException:Exception
    {
        public int StatusCode { get; set; }
        // message is the message that will be displayed to the user
        // innerException is the exception that will be logged
        // statusCode is the status code that will be returned to the user
        public BadRequestException(string message, Exception innerException, int statusCode) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}