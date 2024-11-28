using Microsoft.EntityFrameworkCore;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Domain.Repositories;
using PicPayChallenge.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra.Repositories
{
    public class WalletRepository(PicPayContext context) : IWalletRepository
    {
        public Wallet Create(Wallet wallet)
        {
            var entity = WalletEntity.FromDomain(wallet);
            context.Wallets.Add(entity);
            context.SaveChanges();
            return entity.ToDomain();
        }

        public Wallet? FindBusinessOwnerWallet(int userId)
        {
            var entity = context.Wallets.Include(w => w.User).Where(w => w.User.Kind == UserKind.BUSINESS_OWNER).Where(w => w.User.Id == userId).FirstOrDefault();
            if (entity == null) return null;
            return entity.ToDomain();
        }

        public Wallet? FindByUserId(int userId)
        {
            var entity = context.Wallets.Include(w => w.User).Where(w => w.User.Id == userId).FirstOrDefault();
            if (entity == null)
            {
                return null;
            }
            return entity.ToDomain();
        }

        public Wallet? FindClientWallet(int userId)
        {
            var entity = context.Wallets.Include(w => w.User).Where(w => w.User.Kind == UserKind.CLIENT).Where(w => w.User.Id == userId).FirstOrDefault();
            if (entity == null) return null;
            return entity.ToDomain();
        }

        public IEnumerable<Wallet> UpdateWallets(IEnumerable<Wallet> wallets)
        {
            var entities = wallets
                .Select(we =>
                {
                    var walletEntityFromContext = context.Wallets.Where(w => w.Id == we.Id).First();
                    walletEntityFromContext.Amount = we.Amount;
                    return walletEntityFromContext;
                });
            context.Wallets.UpdateRange(entities);
            context.SaveChanges();
            return entities.Select(w => w.ToDomain());
        }
    }
}
