using PicPayChallenge.Domain.DTOs;
using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.UseCases
{
    public interface ICreateClientUseCase
    {
        public Client CreateClient(ICreateClientDTO createClientDTO);
    }
}
