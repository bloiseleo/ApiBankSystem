using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Application.DTOs
{
    public record NotifyDetailDTO
    {
        public bool Authorization { get; set; }
    }
    public record NotifyDTO
    {
        public string Status { get; set; }
        public NotifyDetailDTO Data { get; set; }
    }
}
