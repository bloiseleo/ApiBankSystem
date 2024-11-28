using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Api.DTOs;
using PicPayChallenge.Application.UseCases;
using PicPayChallenge.Domain.UseCases;
using PicPayChallenge.Infra;

namespace PicPayChallenge.Api.Controllers
{
    public class BusinessOwnerController(ICreateBusinessOwnerUseCase createBusinessOwnerUseCase, IGetBusinessOwnerUseCase getBusinessOwnerUseCase): ApiController
    {
        [HttpPost]
        public IActionResult Create([FromBody] CreateBusinessOwnerDTO createBusinessOwnerDTO, PicPayContext context)
        {

            var businessOwner = createBusinessOwnerUseCase.CreateBusinessOwner(createBusinessOwnerDTO);
            Uri.TryCreate("/api/businessowner/" + businessOwner.Id, UriKind.Relative, out Uri result);
            return Created(result, new BaseResponseDTO()
            {
                Message = $"Business Owner of ID {businessOwner.Id} created successfully",
                Status = System.Net.HttpStatusCode.Created
            });
        }
        [HttpGet("{businessOwnerId}")]
        [Authorize]
        public IActionResult GetBusinessOwner(string businessOwnerId)
        {
            var businessOwner = getBusinessOwnerUseCase.GetBusinessOwner(new GetBusinessOwnerDTO
            {
                Id = businessOwnerId,
            });
            return Ok(new DataResponseDTO
            {
                Data = businessOwner,
                Message = "BusinessOwner Found!",
                Status = System.Net.HttpStatusCode.OK
            });
        }
    }
}
