using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Exceptions
{
    public class BusinessOwnerNotFound : BusinessException
    {
        public BusinessOwnerNotFound(string id) : base($"BusinessOwner {id} not found")
        {
        }
    }
}
