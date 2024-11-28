using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Repositories
{
    public interface IBusinessOwnerRepository
    {
        public BusinessOwner Create(BusinessOwner owner);
        public bool ExistsByEmailOrCnpj(string email, string document);
        public BusinessOwner? FindById(int Id);
    }
}
