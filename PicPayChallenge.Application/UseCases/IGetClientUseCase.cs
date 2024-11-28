using PicPayChallenge.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Application.UseCases
{
    public interface IGetClientUseCase
    {
        public IClientResult GetClient(IGetClientDTO getClientDTO);
    }
}
