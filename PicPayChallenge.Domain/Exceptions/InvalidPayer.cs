using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Exceptions
{
    public class InvalidPayer(): BusinessException("Payer Invalid. Select another one")
    {
    }
}
