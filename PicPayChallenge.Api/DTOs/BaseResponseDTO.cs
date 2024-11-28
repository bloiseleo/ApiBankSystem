using System.Net;

namespace PicPayChallenge.Api.DTOs
{
    public class BaseResponseDTO
    {
        public string Message { get; set; }
        public string Time { get; set; } = DateTime.UtcNow.ToString();
        public HttpStatusCode Status { get; set; }
    }
}
