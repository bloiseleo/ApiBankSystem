using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Application.UseCases
{
    public interface IGetPaginatedTransactions
    {
        public IPageDTO<ITransactionResultDTO> PaginateTransactions(PageRequest request, string userId);
    }
}
