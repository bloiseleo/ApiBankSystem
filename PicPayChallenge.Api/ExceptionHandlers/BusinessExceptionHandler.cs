using Microsoft.AspNetCore.Diagnostics;
using PicPayChallenge.Api.DTOs;
using PicPayChallenge.Domain.Exceptions;
using System.Net;

namespace PicPayChallenge.Api.ExceptionHandlers
{
    public class BusinessExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if(exception is not BusinessException)
            {
                return false;
            }
            var businessException = exception as BusinessException;
            var response = new BaseResponseDTO()
            {
                Message = businessException.Message,
                Status = HttpStatusCode.UnprocessableEntity
            };
            httpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
