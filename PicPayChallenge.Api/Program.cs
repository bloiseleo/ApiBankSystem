using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Api.DTOs;
using PicPayChallenge.Api.ExceptionHandlers;
using PicPayChallenge.Application;
using PicPayChallenge.Application.Services;
using PicPayChallenge.Application.UseCases;
using PicPayChallenge.Domain.Repositories;
using PicPayChallenge.Domain.UseCases;
using PicPayChallenge.Infra;
using PicPayChallenge.Infra.Repositories;
using PicPayChallenge.Infra.Services;
using PicPayChallenge.Infra.UseCases;

namespace PicPayChallenge.Api
{
    public class Program
    {
        private static UnprocessableEntityObjectResult ConfigureInvalidModelStateFactory(ActionContext context)
        {
            var errors = context.ModelState.Where(e => e.Value?.Errors.Count > 0).Select(e => {
                return new InvalidModelDetailDTO()
                {
                    Field = e.Key,
                    Message = e.Value?.Errors.FirstOrDefault()?.ErrorMessage ?? ""
                };
            }).ToArray();
            return new UnprocessableEntityObjectResult(
                new InvalidModelResponseDTO()
                {
                    Errors = errors,
                    Message = "Invalid data",
                    Status = System.Net.HttpStatusCode.UnprocessableEntity
                }
            );
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddPicPayDbContext();
            builder.AddJwtAuthentication();
            
            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = ConfigureInvalidModelStateFactory;
                });

            builder.Services.AddRouting(configuration =>
            {
                configuration.LowercaseUrls = true;
                configuration.LowercaseQueryStrings = true;
            });

            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IBusinessOwnerRepository, BusinessOwnerRepository>();
            builder.Services.AddScoped<ICreateBusinessOwnerUseCase, CreateBusinessOwnerUseCase>();
            builder.Services.AddScoped<ICreateClientUseCase, CreateClientUseCase>();
            builder.Services.AddScoped<IWalletRepository, WalletRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<ITransferUseCase, TransferUseCase>();
            builder.Services.AddScoped<IGetClientUseCase, GetClientUseCase>();
            builder.Services.AddScoped<IGetBusinessOwnerUseCase, GetBusinessOwnerUseCase>();
            builder.Services.AddSingleton<IAuthorizeService, AuthorizeService>();
            builder.Services.AddSingleton<IEmailNotifierService, EmailNotifierService>();

            builder.AddExceptionHandlers();

            var app = builder.Build();

            app.UseAppExceptionHandler();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
