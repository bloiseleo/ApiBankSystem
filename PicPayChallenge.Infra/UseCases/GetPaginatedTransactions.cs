using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Application.UseCases;
using PicPayChallenge.Domain.DTOs;
using PicPayChallenge.Domain.Repositories;

namespace PicPayChallenge.Infra.UseCases
{
    public class GetPaginatedTransactions(ITransactionRepository repository): IGetPaginatedTransactions
    {
        public IPageDTO<ITransactionResultDTO> PaginateTransactions(PageRequest request, string userId)
        {
            if(!int.TryParse(userId, out var id))
            {
                throw new Exception($"Id {id} is not valid");
            };
            var page = repository.CreateTransactionPage(request.PageSize, request.PageIndex, id);
            return new PageDTO()
            {
                Data = page.Item1.Select(t => new TransactionResult()
                {
                    Amount = t.Amount,
                    Id = t.Id.ToString(),
                    PayeeId = t.From.Id.ToString(),
                    PayerId = t.To.Id.ToString(),
                    Status = t.Status,
                }),
                PageIndex = request.PageIndex,
                TotalPages = page.Item2,
            };
        }
    }
}
