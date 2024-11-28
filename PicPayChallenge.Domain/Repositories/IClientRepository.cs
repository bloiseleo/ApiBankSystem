using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Repositories
{
    public interface IClientRepository
    {
        public bool ExistsByEmailOrCpf(string email, string document);
        public Client Create(Client user);
        public Client? FindByEmail(string email);
        public Client? FindById(int Id);
    }
}
