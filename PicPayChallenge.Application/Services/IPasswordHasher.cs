using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Application.Services
{
    public interface IPasswordHasher
    {
        public string Hash(string password, User user);
        public bool VerifyPassword(string password, User user); 
    }
}
