using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Application.DTOs;
using PicPayChallenge.Api.DTOs;
using PicPayChallenge.Application.UseCases;
using PicPayChallenge.Domain.UseCases;
using System.Security.Claims;
using PicPayChallenge.Domain.DTOs;
using System;

namespace PicPayChallenge.Api.Controllers
{
    public class TransferController(
        ITransferUseCase transferUseCase,
        IGetPaginatedTransactions getPaginatedTransactions
    ): ApiController
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Transfer([FromBody] TransferDTO transferDTO)
        {
            var success = await transferUseCase.Transfer(transferDTO);
            if (success == false) {
                return Unauthorized(new BaseResponseDTO
                {
                    Message = "Transference was not authorized",
                    Status = System.Net.HttpStatusCode.Unauthorized,
                });
            }
            return Ok(new BaseResponseDTO
            {
                Message = "Transference Complete successfully!",
                Status = System.Net.HttpStatusCode.OK,
            });
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetTransactions([FromQuery(Name = "Page")] int page = 1, [FromQuery(Name = "Size")] int size = 10)
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            var pageDTO = getPaginatedTransactions.PaginateTransactions(new PageRequest
            {
                PageIndex = page,
                PageSize = size
            }, id.Value);
            if(pageDTO.PageIndex != pageDTO.TotalPages)
            {
                var relativePath = $"/api/transfer?page={pageDTO.PageIndex + 1}&size={size}";

                Uri.TryCreate(relativePath, UriKind.Relative,out var nextPageUri);
                return Ok(new PaginatedResponseDTO<ITransactionResultDTO>()
                {
                    Message = "Transactions paginated successfully",
                    Page = pageDTO,
                    Status = System.Net.HttpStatusCode.OK,
                    NextPage = nextPageUri
                });
            }

            return Ok(new PaginatedResponseDTO<ITransactionResultDTO>()
            {
                Message = "Transactions paginated successfully",
                Page = pageDTO,
                Status = System.Net.HttpStatusCode.OK,
                NextPage = null
            });
        }
    }
}
