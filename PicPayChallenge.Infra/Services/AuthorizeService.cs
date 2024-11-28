using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra.Services
{
    public class AuthorizeService() : IAuthorizeService
    {
        public async Task<bool> Authorize()
        {
            var httpClient = new HttpClient();
            try
            {
                var stream = await httpClient.GetStringAsync("https://util.devi.tools/api/v2/authorize");
                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                var data = JsonSerializer.Deserialize<AuthorizeDTO>(stream, options);
                ArgumentNullException.ThrowIfNull(data);
                return data.Data.Authorization;
            }
            catch (HttpRequestException exception)
            {
                return false;
            }
        }
    }
}
