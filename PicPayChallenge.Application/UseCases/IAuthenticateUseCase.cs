using PicPayChallenge.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.UseCases
{
    public interface IAuthenticateUseCase
    {
        public string Authenticate(IAuthenticateUserDTO data);
    }
}
