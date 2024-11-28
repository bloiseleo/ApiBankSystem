using PicPayChallenge.Application.Services;
using PicPayChallenge.Domain;
using PicPayChallenge.Domain.DTOs;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Domain.Exceptions;
using PicPayChallenge.Domain.Repositories;
using PicPayChallenge.Domain.UseCases;

namespace PicPayChallenge.Infra.UseCases
{
    public class CreateBusinessOwnerUseCase (
        IBusinessOwnerRepository businessOwnerRepository,
        IWalletRepository walletRepository,
        PicPayContext context,
        IPasswordHasher passwordHasher
    ): ICreateBusinessOwnerUseCase
    {
        public BusinessOwner CreateBusinessOwner(ICreateBusinessOwnerDTO createBusinessOwnerDTO)
        {
            if(businessOwnerRepository.ExistsByEmailOrCnpj(createBusinessOwnerDTO.Email, createBusinessOwnerDTO.Cnpj))
            {
                throw new EmailOrDocumentAlreadyTaken(createBusinessOwnerDTO.Email, createBusinessOwnerDTO.Cnpj);
            }
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var businessOwner = new BusinessOwner
                {
                    Document = createBusinessOwnerDTO.Cnpj,
                    Email = createBusinessOwnerDTO.Email,
                    Name = createBusinessOwnerDTO.Name,
                    Password = createBusinessOwnerDTO.Password,
                };
                businessOwner.Password = passwordHasher.Hash(businessOwner.Password, businessOwner);
                Wallet wallet = walletRepository.Create(new Wallet()
                {
                    Amount = 0.0m,
                    User = businessOwner
                });
                transaction.Commit();
                businessOwner.Id = wallet.User.Id;
                return businessOwner;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
