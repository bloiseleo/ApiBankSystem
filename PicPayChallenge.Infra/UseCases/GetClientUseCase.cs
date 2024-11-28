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
    public class GetClientUseCase(IWalletRepository walletRepository): IGetClientUseCase
    {
        public IClientResult GetClient(IGetClientDTO getClientDTO)
        {
            if(!int.TryParse(getClientDTO.Id, out var clientId))
            {
                throw new InvalidClientId(getClientDTO.Id);
            }
            var client = walletRepository.FindByUserId(clientId);
            if (client == null) 
            {
                throw new ClientNotFound(getClientDTO.Id);
            }
            return ClientResult.FromWallet(client);
        }
    }
}
