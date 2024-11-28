using Microsoft.AspNetCore.Identity;
using PicPayChallenge.Application.Services;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Infra.Entities;

namespace PicPayChallenge.Infra.Services
{
    public class ApiPasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<UserEntitiy> _passwordHasher;
        public ApiPasswordHasher() {
            _passwordHasher = new PasswordHasher<UserEntitiy>();
        }
        public string Hash(string password, User user)
        {
            return _passwordHasher.HashPassword(UserEntitiy.FromDomain(user), password);
        }
        public bool VerifyPassword(string password, User user)
        {
            var passwordResult = _passwordHasher.VerifyHashedPassword(UserEntitiy.FromDomain(user), user.Password, password);
            return passwordResult == PasswordVerificationResult.Success;
        }
    }
}
