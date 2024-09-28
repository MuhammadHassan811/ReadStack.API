using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ReadStack.API.ExceptionHandler
{
    public class ApiExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            int statusCode;
            string title;

            if (exception is ArgumentException)
            {
                statusCode = StatusCodes.Status400BadRequest;
                title = "Invalid Argument.";
            }
            else if (exception is InvalidOperationException)
            {
                statusCode = StatusCodes.Status409Conflict;
                title = "Operation Not Allowed";
            }
            else
            {
                statusCode = StatusCodes.Status500InternalServerError;
                title = "Server Error";
            }

            var details = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = exception.Message
            };


            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);
            return true;
        }
    }
}
