using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Application.DTOs
{
    public record AuthorizeDetailDTO
    {
        public bool Authorization { get; set; }
    }
    public record AuthorizeDTO
    {
        public string Status { get; set; }
        public AuthorizeDetailDTO Data { get; set; }
    }
}
