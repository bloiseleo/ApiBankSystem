using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public User From { get; set; }
        public User To { get; set; }
        public TransactionStatus Status { get; set; }
        public Decimal Amount { get; set; }
    }
}
