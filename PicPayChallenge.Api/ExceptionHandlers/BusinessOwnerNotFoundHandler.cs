using Microsoft.AspNetCore.Diagnostics;
using PicPayChallenge.Api.DTOs;
using PicPayChallenge.Domain.Exceptions;
using System.Net;

namespace PicPayChallenge.Api.ExceptionHandlers
{
    public class BusinessOwnerNotFoundHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if(exception is not BusinessOwnerNotFound)
            {
                return false;
            }
            httpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;
            await httpContext.Response.WriteAsJsonAsync(new BaseResponseDTO
            {
                Message = exception.Message,
                Status = HttpStatusCode.NotFound,
            });
            return true;
        }
    }
}
