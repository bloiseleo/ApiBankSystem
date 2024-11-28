using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Repositories
{
    public interface ITransactionRepository
    {
        public Transaction Create(Transaction transaction);
    }
}
