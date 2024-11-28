using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Api.DTOs;
using PicPayChallenge.Domain.UseCases;
using System.Net;

namespace PicPayChallenge.Api.Controllers
{
    public class LoginController(IAuthenticateUseCase authenticateUseCase): ApiController
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO data)
        {
            var token = authenticateUseCase.Authenticate(data);
            return Ok(new LoginResponseDTO
            {
                Message = "Authenticated Successfully",
                Status = HttpStatusCode.OK,
                Token = token
            });
        }
    }
}
