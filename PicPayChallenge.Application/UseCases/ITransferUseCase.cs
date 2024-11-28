using PicPayChallenge.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.UseCases
{
    public interface ITransferUseCase
    {
        public Task<bool> Transfer(ITransferDTO transferDTO);
    }
}
