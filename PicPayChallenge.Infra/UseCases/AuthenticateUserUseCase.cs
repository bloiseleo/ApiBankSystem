using PicPayChallenge.Application.Services;
using PicPayChallenge.Domain.DTOs;
using PicPayChallenge.Domain.Repositories;
using PicPayChallenge.Domain.UseCases;
using PicPayChallenge.Domain.Exceptions;

namespace PicPayChallenge.Infra.UseCases
{
    public class AuthenticateUserUseCase(IClientRepository clientRepository, ITokenBuilder tokenBuilder, IPasswordHasher passwordHasher): IAuthenticateUseCase
    {
        public string Authenticate(IAuthenticateUserDTO data)
        {
            var user = clientRepository.FindByEmail(data.Email);
            if(user == null)
            {
                throw new Unauthorized("Invalid Credentials");
            }
            if(!passwordHasher.VerifyPassword(data.Password, user))
            {
                throw new Unauthorized("Invalid Credentials");
            }
            return tokenBuilder.Build(user);
        }
    }
}
