using PicPayChallenge.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace PicPayChallenge.Api.DTOs
{
    public class TransferDTO : ITransferDTO
    {
        [Required(ErrorMessage = "Value must be provided")]
        [Range(1, double.PositiveInfinity, ErrorMessage = "Value must be bigger than 0")]
        public decimal Value { get; set; }
        [Required(ErrorMessage = "Payer must be provided")]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Payer ID provided")]
        public int Payer { get; set; }
        [Required(ErrorMessage = "Payee must be provided")]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Payee ID provided")]
        public int Payee { get;set ; }
    }
}
