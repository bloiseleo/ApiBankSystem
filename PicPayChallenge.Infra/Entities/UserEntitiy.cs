using Microsoft.EntityFrameworkCore;
using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra.Entities
{
    [Index(nameof(Document)), Index(nameof(Document))]
    public class UserEntitiy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Document { get; set; }
        [Required]
        public UserKind Kind { get; set; }
        public Client ToClient()
        {
            return new Client
            {
                Id = Id,
                Cpf = Document,
                Email = Email,
                Name = Name,
                Password = Password
            };
        }
        public BusinessOwner ToBusinessOwner()
        {
            return new BusinessOwner { 
                Id = Id,
                Document = Document,
                Email = Email,
                Name = Name,
                Password= Password
            };
        }

        public static UserEntitiy FromDomain(User user)
        {
            if (user is Client client) 
            { 
                return ClientEntity.FromDomain(client);
            }
            if (user is BusinessOwner business)
            {
                return BusinessOwnerEntity.FromDomain(business);
            }
            throw new ArgumentOutOfRangeException("User must be a Client or BusinessOwner");
        }
    }
}
