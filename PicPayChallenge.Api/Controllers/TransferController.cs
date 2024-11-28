using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Api.DTOs;
using PicPayChallenge.Domain.UseCases;

namespace PicPayChallenge.Api.Controllers
{
    public class TransferController(ITransferUseCase transferUseCase): ApiController
    {
        [HttpPost]
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
    }
}
