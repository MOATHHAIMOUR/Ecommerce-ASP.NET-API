using System.Net;

namespace Ecommerce.Application.Common.ApiResponse
{
    public static class ApiResponseHandler
    {
        // Generates a response for a successful deletion
        public static ApiResponse<T> Deleted<T>(string message = "Deleted Successfully")
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message
            };
        }

        
        // Generates a success response with entity data and optional metadata
        public static ApiResponse<T> Success<T>(T data, object? meta = null, string message = "Operation Done Successfully")
        {
            return new ApiResponse<T>()
            {
                Data = data,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message,
                Meta = meta
            };
        }

       
        // Generates a success response without entity data but with optional metadata
        public static ApiResponse<T> Success<T>(string message = "Operation Done Successfully", object meta = null)
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message,
                Meta = meta
            };
        }

        
        // Generates a response for unauthorized access
        public static ApiResponse<T> Unauthorized<T>(string message = "Unauthorized")
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false, // Unauthorized is typically considered a failed request
                Message = message
            };
        }

        
        // Generates a bad request response
        public static ApiResponse<T> BadRequest<T>(string message = "Bad Request")
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message
            };
        }

       
        // Generates a not found response
        public static ApiResponse<T> NotFound<T>(string message = "Not Found")
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message
            };
        }

       
        // Generates a response for a successfully created resource, including entity data
        public static ApiResponse<T> Created<T>(T entity, object meta = null, string message = "Created")
        {
            return new ApiResponse<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = message,
                Meta = meta
            };
        }

       
        // Generates a response for a successfully created resource, with optional custom message
        public static ApiResponse<T> Created<T>(T id, string message = "Created", object meta = null)
        {
            return new ApiResponse<T>()
            {
                Data = id,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = message,
                Meta = meta
            };
        }
    }
}
