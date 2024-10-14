using Ecommerce.Application.Common.ApiResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ecommerce.Api.Controllers.Base
{
    [ApiController]
    public class AppController : ControllerBase
    {

        protected readonly IMediator _mediator;

        protected AppController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public ObjectResult NewResult<T>(ApiResponse<T> response)
        {

            return response.StatusCode switch
            {
                HttpStatusCode.OK => CreateObjectResult(response, StatusCodes.Status200OK),
                HttpStatusCode.Created => new CreatedResult(GetLocationHeader(response), response),
                HttpStatusCode.Unauthorized => CreateObjectResult(response, StatusCodes.Status401Unauthorized),
                HttpStatusCode.BadRequest => CreateObjectResult(response, StatusCodes.Status400BadRequest),
                HttpStatusCode.NotFound => CreateObjectResult(response, StatusCodes.Status404NotFound),
                HttpStatusCode.Accepted => CreateObjectResult(response, StatusCodes.Status202Accepted),
                HttpStatusCode.UnprocessableEntity => CreateObjectResult(response, StatusCodes.Status422UnprocessableEntity),
                _ => CreateObjectResult(response, StatusCodes.Status500InternalServerError) // Default to 500 Internal Server Error
            };
        }


        private ObjectResult CreateObjectResult<T>(ApiResponse<T> response, int statusCode)
        {
            var objectResult = new ObjectResult(response)
            {
                StatusCode = statusCode
            };

            // Add custom headers if needed (optional)
            AddCustomHeaders(objectResult);

            return objectResult;
        }

        private string GetLocationHeader<T>(ApiResponse<T> response)
        {
            // Add logic to get the resource location URI for Created(201) responses
            // Example: return the URI to the newly created resource
            return string.Empty; // Modify this based on your requirements
        }

        private void AddCustomHeaders(ObjectResult objectResult)
        {
            // Add any custom headers if required
            //objectResult.Headers.Add("X-Custom-Header", "HeaderValue"); // Example
        }

        private void LogError<T>(ApiResponse<T> response)
        {
            // Implement error logging (log status code, response details, etc.)
            // Example:
            Console.WriteLine($"Error: {response.StatusCode}, Message: {response.Message}");
        }

    }
}
