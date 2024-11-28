using Microsoft.EntityFrameworkCore;
using PicPayChallenge.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PicPayChallenge.Infra.Entities
{
    public class ClientEntity: UserEntitiy
    {
        
        public static ClientEntity FromDomain(Client client)
        {
            return new ClientEntity
            {
                Id = client.Id,
                Document = client.Cpf,
                Password = client.Password,
                Name = client.Name,
                Email = client.Email,
                Kind = UserKind.CLIENT
            };
        }
    }
}
