using Common.Api;

namespace Common.Exceptions
{
    public class AppException : Exception
    {
        public ApiResultStatusCode StatusCode { get; set; }

        public AppException(string message, ApiResultStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
