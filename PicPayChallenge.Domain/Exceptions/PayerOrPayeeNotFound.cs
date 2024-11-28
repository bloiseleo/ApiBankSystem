using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Exceptions
{
    public class PayerOrPayeeNotFound(int payer, int payee): BusinessException($"Payer {payer} or Payee {payee} not found")
    {
    }
}
