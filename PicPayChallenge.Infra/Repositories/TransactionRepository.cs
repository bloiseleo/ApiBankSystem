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
    public class TransactionRepository(PicPayContext context): ITransactionRepository
    {
        private void injectTrackedUsers(TransactionEntity entity)
        {
            var from = context.Users.Where(u => u.Id == entity.From.Id).First();
            var to = context.Users.Where(u => u.Id == entity.To.Id).First();
            entity.From = from;
            entity.To = to;
        }
        public Transaction Create(Transaction transaction)
        {
            var entity = TransactionEntity.FromDomain(transaction);
            injectTrackedUsers(entity);
            context.Transactions.Add(entity);
            context.SaveChanges();
            return entity.ToDomain();
        }
    }
}
