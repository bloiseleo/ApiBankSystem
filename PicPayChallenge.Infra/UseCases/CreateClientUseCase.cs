using PicPayChallenge.Application.Services;
using PicPayChallenge.Domain;
using PicPayChallenge.Domain.DTOs;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Domain.Exceptions;
using PicPayChallenge.Domain.Repositories;
using PicPayChallenge.Domain.UseCases;

namespace PicPayChallenge.Infra.UseCases
{
    public class CreateClientUseCase(IClientRepository clientRepository, IWalletRepository walletRepository, PicPayContext context, IPasswordHasher passwordHasher): ICreateClientUseCase
    {
        public Client CreateClient(ICreateClientDTO createClientDTO)
        {
            if (clientRepository.ExistsByEmailOrCpf(email: createClientDTO.Email, document: createClientDTO.Cpf))
            {
                throw new EmailOrDocumentAlreadyTaken(createClientDTO.Email, createClientDTO.Cpf);
            }
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var client = new Client { Cpf = createClientDTO.Cpf, Email = createClientDTO.Email, Name = createClientDTO.Name, Password =  createClientDTO.Password };
                client.Password = passwordHasher.Hash(client.Password, client);
                var wallet = walletRepository.Create(new Wallet()
                {
                    Amount = 0.0m,
                    User = client,
                });
                client.Id = wallet.User.Id;
                transaction.Commit();
                return client;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
