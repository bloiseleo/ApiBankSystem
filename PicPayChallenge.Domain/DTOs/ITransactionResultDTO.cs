using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.DTOs
{
    public interface ITransactionResultDTO
    {
        public string Id { get; set; }
        public string PayerId { get; set; }
        public string PayeeId { get; set; }
        public TransactionStatus Status { get; set; }
        public string StatusDescription { get; }
        public Decimal Amount { get; set; }
    }
}
