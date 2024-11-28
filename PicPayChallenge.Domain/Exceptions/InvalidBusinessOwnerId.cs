using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Exceptions
{
    public class InvalidBusinessOwnerId(string Id): BusinessException($"BusinessOwner {Id} is not valid")
    {
    }
}
