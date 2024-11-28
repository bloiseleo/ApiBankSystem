namespace PicPayChallenge.Api.DTOs
{
    public class InvalidModelResponseDTO: BaseResponseDTO
    {
        public InvalidModelDetailDTO[] Errors { get; set; }
    }
}
