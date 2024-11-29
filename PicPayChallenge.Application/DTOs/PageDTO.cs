using PicPayChallenge.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Application.DTOs
{
    public class PageDTO : IPageDTO<ITransactionResultDTO>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<ITransactionResultDTO> Data { get; set; }
    }
}
