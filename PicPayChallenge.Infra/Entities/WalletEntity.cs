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
    public class WalletEntity
    {
        [Key]
        public int Id { get; set; }
        public UserEntitiy User { get; set; }
        public Decimal Amount { get; set; }

        public Wallet ToDomain()
        {
            return new Wallet
            {
                Id = Id,
                Amount = Amount,
                User = User.Kind == UserKind.CLIENT ? User.ToClient() : User.ToBusinessOwner(),
            };
        }
        public static WalletEntity FromDomain(Wallet wallet)
        {
            return new WalletEntity
            {
                Id = wallet.Id,
                Amount = wallet.Amount,
                User = UserEntitiy.FromDomain(wallet.User)
            };
        }
    }
}
 