using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra.Entities
{
    public class BusinessOwnerEntity: UserEntitiy
    {
        public static BusinessOwnerEntity FromDomain(BusinessOwner businessOwner)
        {
            return new BusinessOwnerEntity
            {
                Document = businessOwner.Cnpj,
                Email = businessOwner.Email,
                Id = businessOwner.Id,
                Kind = UserKind.BUSINESS_OWNER,
                Name = businessOwner.Name,
                Password = businessOwner.Password,
            };
        }
    }
}
