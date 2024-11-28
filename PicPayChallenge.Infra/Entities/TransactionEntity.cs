using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra.Entities
{
    public class TransactionEntity
    {
        [Key]
        public int Id { get; set; }
        public UserEntitiy From { get; set; }
        public UserEntitiy To { get; set; } 
        public TransactionStatus Status { get; set; }
        public Decimal Amount { get; set; }

        public static TransactionEntity FromDomain(Transaction transaction)
        {
            return new TransactionEntity
            {
                Id = transaction.Id,
                From = UserEntitiy.FromDomain(transaction.From),
                To = UserEntitiy.FromDomain(transaction.To),
                Status = transaction.Status,
                Amount = transaction.Amount
            };
        }
        public Transaction ToDomain()
        {
            return new Transaction()
            {
                Id = Id,
                Amount = Amount,
                Status = Status,
                From = From.Kind == UserKind.CLIENT ? From.ToClient() : From.ToBusinessOwner(),
                To = To.Kind == UserKind.CLIENT ? To.ToClient() : To.ToBusinessOwner()
            };
        }
    }
}
