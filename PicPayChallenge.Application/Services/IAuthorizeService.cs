using PicPayChallenge.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Application.Services
{
    public interface IAuthorizeService
    {
        public Task<bool> Authorize();
    }
}
