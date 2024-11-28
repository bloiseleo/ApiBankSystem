using Microsoft.AspNetCore.Diagnostics;
using PicPayChallenge.Api.DTOs;
using PicPayChallenge.Domain.Exceptions;
using System.Net;

namespace PicPayChallenge.Api.ExceptionHandlers
{
    public class UnauthorizedExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception == null) return false;
            if (exception is not Unauthorized) return false;
            httpContext.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
            await httpContext.Response.WriteAsJsonAsync(new BaseResponseDTO
            {
                Message = exception.Message,
                Status = HttpStatusCode.Unauthorized,
            }, cancellationToken);
            return true;
        }
    }
}
