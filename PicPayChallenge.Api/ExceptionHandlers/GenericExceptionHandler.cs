using Microsoft.AspNetCore.Diagnostics;
using PicPayChallenge.Api.DTOs;
using System.Net;

namespace PicPayChallenge.Api.ExceptionHandlers
{
    public class GenericExceptionHandler(ILogger<GenericExceptionHandler> logger): IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError($"Unknown exception occurred! - {exception.StackTrace}");
            var response = new BaseResponseDTO()
            {
                Message = "Internal Server Error",
                Status = HttpStatusCode.InternalServerError
            };
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
