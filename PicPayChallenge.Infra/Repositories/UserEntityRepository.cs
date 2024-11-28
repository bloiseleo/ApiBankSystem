using PicPayChallenge.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra.Repositories
{
    internal class UserEntityRepository(PicPayContext context)
    {
        public UserEntitiy? FindById(int id)
        {
            return context.Users.Where(u =>  u.Id == id).FirstOrDefault();
        }
        public bool ExistsByEmailOrDocument(string email, string document)
        {
            return context.Users.Any(u =>  u.Email == email|| u.Document == document);
        }
        public UserEntitiy? FindByEmailOrDocument(string email, string document)
        {
            return context.Users.FirstOrDefault(u => u.Email == email || u.Document == document);
        }
        public UserEntitiy Create(UserEntitiy entity) 
        { 
            context.Users.Add(entity);
            context.SaveChanges();
            return entity;
        }
        public UserEntitiy? FindByEmail(string email)
        {
            return context.Users.FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}
