using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.DTOs
{
    public interface ITransferDTO
    {
        public Decimal Value { get; set; }
        public int Payer { get; set; }
        public int Payee { get; set; }
    }
}
