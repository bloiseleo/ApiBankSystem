using PicPayChallenge.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace PicPayChallenge.Api.DTOs
{
    public class CreateClientDTO: ICreateClientDTO
    {
        [Required(ErrorMessage = "name must be provided")]
        public string Name { get; set; }
        [Required(ErrorMessage = "password must be provided")]
        public string Password { get; set; }
        [Required(ErrorMessage = "cpf must be provided")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "email must be provided")]
        public string Email { get; set; }
    }
}
