using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Domain.Exceptions
{
    public class EmailOrDocumentAlreadyTaken(string email, string document) : BusinessException($"Email {email} or Document {document} already taken")
    {

    }
}
