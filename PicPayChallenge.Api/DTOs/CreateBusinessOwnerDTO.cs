using PicPayChallenge.Domain.DTOs;
using PicPayChallenge.Infra.Validations;
using System.ComponentModel.DataAnnotations;

namespace PicPayChallenge.Api.DTOs
{
    public class CreateBusinessOwnerDTO : ICreateBusinessOwnerDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be provided")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password must be provided")]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email must be provided")]
        [EmailAddress(ErrorMessage = "Email must be valid")]
        public string Email { get ;set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "CNPJ must be provided")]
        [Cnpj(ErrorMessage = "CNPJ must be valid")]
        public string Cnpj { get ;set; }
    }
}
