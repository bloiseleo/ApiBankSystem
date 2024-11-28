using Microsoft.AspNetCore.Diagnostics;
using PicPayChallenge.Api.DTOs;
using PicPayChallenge.Domain;
using System.Net;

namespace PicPayChallenge.Api.ExceptionHandlers
{
    public static class ApiExceptionHandlerStartUp
    {
        public static void AddExceptionHandlers(this WebApplicationBuilder builder)
        {
            builder.Services.AddExceptionHandler<BusinessExceptionHandler>();
            builder.Services.AddExceptionHandler<ClientNotFoundHandler>();
            builder.Services.AddExceptionHandler<BusinessExceptionHandler>();
            builder.Services.AddExceptionHandler<GenericExceptionHandler>();
        }
        public static void UseAppExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(exceptionHandlerBuilder =>
            {
                exceptionHandlerBuilder.Build();
            });
        }
    }
}
