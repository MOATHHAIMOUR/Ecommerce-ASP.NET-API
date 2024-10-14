using System.Net;

namespace Ecommerce.Application.Common.ApiResponse
{
    public class ApiResponse<T>
    {
        // Success response with data and optional message
        public ApiResponse() { }
        public ApiResponse(T data, string? message = null)
        {
            Succeeded = true;
            StatusCode = HttpStatusCode.OK;  // Default to 200 OK
            Message = string.IsNullOrEmpty(message) ? "Success" : message;
            Data = data;
            Errors = [];
        }

        // Failure response with message and errors
        public ApiResponse(string message, List<string>? errors = null, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Succeeded = false;
            Message = message;
            StatusCode = statusCode;
            Errors = errors ?? [];
        }

        // Failure response with custom status code and message
        public ApiResponse(HttpStatusCode statusCode, string? message = null)
        {
            Succeeded = false;
            StatusCode = statusCode;
            Message = string.IsNullOrEmpty(message) ? "Failure" : message;
            Errors = [];
        }

        // Optional metadata (can be used for pagination, etc.)
        public object? Meta { get; set; }
        public bool Succeeded { get; set; }   // Indicates whether the request succeeded
        public string Message { get; set; }   // Response message for the client
        public List<string> Errors { get; set; }   // Error messages, if any
        public HttpStatusCode StatusCode { get; set; }   // HTTP status code for the response
        public T? Data { get; set; }   // The actual response data
    }
}
