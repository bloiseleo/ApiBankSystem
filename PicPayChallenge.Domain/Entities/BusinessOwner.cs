using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Entities
{
    public class BusinessOwner: User
    {
        public string Cnpj { get => Document; }

    }
}
