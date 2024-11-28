using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PicPayChallenge.Application;
using PicPayChallenge.Application.Configuration;
using PicPayChallenge.Application.Services;
using PicPayChallenge.Domain.UseCases;
using PicPayChallenge.Infra.Services;
using PicPayChallenge.Infra.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra
{
    public static class InfraStartup
    {
        public static void AddPicPayDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<PicPayContext>(configuration =>
            {
                var connectionString = builder.Configuration.GetConnectionString("Default");
                ArgumentNullException.ThrowIfNull(connectionString);
                configuration.UseNpgsql(connectionString);
            });
        }
        private static JwtOptions configureJwtOptions(this WebApplicationBuilder builder)
        {
            var dto = builder.Configuration.GetRequiredSection("JwtOptions");
            var secret = dto.GetValue<string>("secret");
            var iss = dto.GetValue<string>("iss");
            var aud = dto.GetValue<string>("aud");
            ArgumentNullException.ThrowIfNullOrEmpty(aud);
            ArgumentNullException.ThrowIfNullOrEmpty(iss);
            ArgumentNullException.ThrowIfNullOrEmpty(secret);
            return new JwtOptions()
            {
                Aud = aud,
                Iss = iss,
                Secret = Encoding.UTF8.GetBytes(secret)
            };
        }
        public static void AddJwtAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<JwtOptions>(options => {
                var jwtOptions = builder.configureJwtOptions();
                options.Iss = jwtOptions.Iss;
                options.Secret = jwtOptions.Secret;
                options.Aud = jwtOptions.Aud;
            });
            builder.Services.AddAuthentication()
                .AddJwtBearer((options) =>
                {
                    var jwtOptions = builder.configureJwtOptions();
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = jwtOptions.Iss,
                        ValidAudience = jwtOptions.Aud,
                        IssuerSigningKey = new SymmetricSecurityKey(jwtOptions.Secret),
                        
                    };
                });
            builder.Services.AddScoped<ITokenBuilder, TokenBuilder>();
            builder.Services.AddScoped<IAuthenticateUseCase, AuthenticateUserUseCase>();
            builder.Services.AddSingleton<IPasswordHasher, ApiPasswordHasher>();
        }
    }
}
