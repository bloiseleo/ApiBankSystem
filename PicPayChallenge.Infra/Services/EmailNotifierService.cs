using Microsoft.Extensions.Logging;
using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra.Services
{
    public class EmailNotifierService(ILogger<EmailNotifierService> logger): IEmailNotifierService
    {
        public async Task<bool> NotifyEmail(EmailData email)
        {
            try
            {
                using var client = new HttpClient();
                var stream = await client.GetStreamAsync("https://util.devi.tools/api/v1/notify");
                var data = JsonSerializer.Deserialize<NotifyDTO>(stream, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                if (data == null)
                {
                    return false;
                }
                return data.Data.Authorization;
            }
            catch (Exception ex)
            {
                logger.LogWarning($"HTTP error - {ex.StackTrace}");
                return false;
            }
        }
    }
}
