using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Exceptions
{
    public class ClientNotFound(string id): BusinessException($"Client {id} not found")
    {
    }
}
