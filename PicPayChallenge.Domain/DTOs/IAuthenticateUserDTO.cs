using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.DTOs
{
    public interface IAuthenticateUserDTO
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}
