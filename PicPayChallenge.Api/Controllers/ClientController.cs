using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Api.DTOs;
using PicPayChallenge.Application.UseCases;
using PicPayChallenge.Domain.UseCases;
using PicPayChallenge.Infra;
using System.Security.Claims;

namespace PicPayChallenge.Api.Controllers
{
    public class ClientController(ICreateClientUseCase createClientUseCase, IGetClientUseCase getClientUseCase): ApiController
    {
        [HttpPost]
        public IActionResult CreateClient([FromBody] CreateClientDTO createClientDTO, PicPayContext context)
        {
            var client = createClientUseCase.CreateClient(createClientDTO);
            Uri.TryCreate("api/client/" + client.Id, UriKind.Relative, out Uri uri);
            return Created(uri, new BaseResponseDTO
            {
                Message = $"Client of ID {client.Id} created successfully",
                Status = System.Net.HttpStatusCode.Created
            });
        }
        [HttpGet("{clientId}")]
        [Authorize]
        public IActionResult GetClient(string clientId)
        {
            var client = getClientUseCase.GetClient(new GetClientDTO
            {
                Id = clientId
            });
            return Ok(new DataResponseDTO
            {
                Data = client,
                Message = "Client found",
                Status = System.Net.HttpStatusCode.OK
            });
        }
    }
}
