using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Application.UseCases;
using PicPayChallenge.Domain.DTOs;
using PicPayChallenge.Domain.Exceptions;
using PicPayChallenge.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra.UseCases
{
    public class GetBusinessOwnerUseCase(IBusinessOwnerRepository businessOwnerRepository): IGetBusinessOwnerUseCase
    {
        public IBusinessOwnerResult GetBusinessOwner(IGetBusinessOwnerDTO getBusinessOwnerDTO)
        {
            if(!int.TryParse(getBusinessOwnerDTO.Id, out var businessOwnerId))
            {
                throw new InvalidBusinessOwnerId(getBusinessOwnerDTO.Id);
            }
            var entity = businessOwnerRepository.FindById(businessOwnerId);
            if (entity == null) throw new BusinessOwnerNotFound(getBusinessOwnerDTO.Id);
            return new BusinessOwnerResult
            {
                Id = entity.Id,
                Cnpj = entity.Cnpj,
                Email = entity.Email,
                Name = entity.Name,
            };
        }
    }
}
