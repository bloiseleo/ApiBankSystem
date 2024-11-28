using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PicPayChallenge.Application.Configuration;
using PicPayChallenge.Application.Services;
using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PicPayChallenge.Infra.Services
{
    public class TokenBuilder(IOptions<JwtOptions> options) : ITokenBuilder
    {
        private JwtSecurityTokenHandler _handler { get; set; } = new JwtSecurityTokenHandler();
        private SigningCredentials getCredentials()
        {
            var key = new SymmetricSecurityKey(options.Value.Secret);
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }
        public string Build(User user)
        {
            var creds = getCredentials();
            var token = new JwtSecurityToken(
                issuer: options.Value.Iss,
                audience: options.Value.Aud,
                signingCredentials: creds,
                expires: DateTime.Now.AddDays(1),
                claims: GenerateClaims(user)
            );
            return _handler.WriteToken(token);
        }
        public IEnumerable<Claim> GenerateClaims(User user)
        {                                       
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            return claims;
        }
    }
}
