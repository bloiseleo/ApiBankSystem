using PicPayChallenge.Application.Services;
using PicPayChallenge.Domain.DTOs;
using PicPayChallenge.Domain.Repositories;
using PicPayChallenge.Domain.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra.UseCases
{
    public class AuthenticateUserUseCase(IClientRepository clientRepository, ITokenBuilder tokenBuilder, IPasswordHasher passwordHasher): IAuthenticateUseCase
    {
        public string Authenticate(IAuthenticateUserDTO data)
        {
            var user = clientRepository.FindByEmail(data.Email);
            if(user == null)
            {
                throw new UnauthorizedAccessException("Invalid Credentials");
            }
            if(!passwordHasher.VerifyPassword(data.Password, user))
            {
                throw new UnauthorizedAccessException("Invalid Credentials");
            }
            return tokenBuilder.Build(user);
        }
    }
}
