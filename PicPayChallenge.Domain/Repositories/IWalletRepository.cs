using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Repositories
{
    public interface IWalletRepository
    {
        public Wallet Create(Wallet wallet);
        public Wallet? FindByUserId(int userId);
        public IEnumerable<Wallet> UpdateWallets(IEnumerable<Wallet> wallets);
        public Wallet? FindClientWallet(int userId);
        public Wallet? FindBusinessOwnerWallet(int userId); 
    }
}
