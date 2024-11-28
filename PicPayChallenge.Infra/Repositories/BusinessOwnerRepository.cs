using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Domain.Exceptions;
using PicPayChallenge.Domain.Repositories;
using PicPayChallenge.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra.Repositories
{
    public class BusinessOwnerRepository : IBusinessOwnerRepository
    {
        private UserEntityRepository userEntityRepository;
        public BusinessOwnerRepository(PicPayContext context)
        {
            userEntityRepository = new UserEntityRepository(context);
        }
        public BusinessOwner Create(BusinessOwner owner)
        {
            var entity = BusinessOwnerEntity.FromDomain(owner);
            return userEntityRepository.Create(entity).ToBusinessOwner();
        }
        public bool ExistsByEmailOrCnpj(string email, string document)
        {
            return userEntityRepository.ExistsByEmailOrDocument(email, document);
        }
        public BusinessOwner? FindById(int Id)
        {
            var userEntity = userEntityRepository.FindById(Id);
            if (userEntity == null) return null;
            if (userEntity.Kind != UserKind.BUSINESS_OWNER) return null;
            return userEntity.ToBusinessOwner();
        }
    }
}
