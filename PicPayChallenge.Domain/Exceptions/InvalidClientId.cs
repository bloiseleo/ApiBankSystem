using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Exceptions
{
    public class InvalidClientId(string id): BusinessException($"Client Id {id} is not valid")
    {
    }
}
