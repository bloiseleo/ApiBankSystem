using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Application.UseCases;
using PicPayChallenge.Domain.DTOs;
using PicPayChallenge.Domain.Exceptions;
using PicPayChallenge.Domain.Repositories;

namespace PicPayChallenge.Infra.UseCases
{
    public class GetBusinessOwnerUseCase(IWalletRepository walletRepository): IGetBusinessOwnerUseCase
    {
        public IBusinessOwnerResult GetBusinessOwner(IGetBusinessOwnerDTO getBusinessOwnerDTO)
        {
            if(!int.TryParse(getBusinessOwnerDTO.Id, out var businessOwnerId))
            {
                throw new InvalidBusinessOwnerId(getBusinessOwnerDTO.Id);
            }
            var entity = walletRepository.FindBusinessOwnerWallet(businessOwnerId);
            if (entity == null) throw new BusinessOwnerNotFound(getBusinessOwnerDTO.Id);
            return new BusinessOwnerResult
            {
                Id = entity.Id,
                Cnpj = entity.User.Document,
                Email = entity.User.Email,
                Name = entity.User.Name,
                Value = entity.Amount,
            };
        }
    }
}
