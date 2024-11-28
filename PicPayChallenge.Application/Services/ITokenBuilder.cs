using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Application.Services
{
    public interface ITokenBuilder
    {
        string Build(User user);
        IEnumerable<Claim> GenerateClaims(User user);
    }
}
