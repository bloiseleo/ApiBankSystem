using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Entities
{
    public class Client: User
    {
        public string Cpf { get => Document; set => Document = value; }
    }
}
