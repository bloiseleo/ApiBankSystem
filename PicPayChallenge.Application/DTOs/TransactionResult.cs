using PicPayChallenge.Domain.DTOs;
using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Application.DTOs
{
    public class TransactionResult : ITransactionResultDTO
    {
        public string Id { get; set; }
        public string PayerId { get; set; }
        public string PayeeId { get; set; }
        public TransactionStatus Status { get; set; }
        public string StatusDescription { get => Status == TransactionStatus.Success ? "Sucess" : "Error"; }
        public decimal Amount { get; set; }
    }
}
