using PicPayChallenge.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace PicPayChallenge.Api.DTOs
{
    public class LoginDTO: IAuthenticateUserDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email must be provided")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password must be provided")]
        public string Password { get; set; }
    }
}
