using PicPayChallenge.Domain.DTOs;

namespace PicPayChallenge.Api.DTOs
{
    public class PaginatedResponseDTO<T>: BaseResponseDTO
    {
        public IPageDTO<T> Page { get; set; }
        public Uri? NextPage { get; set; }
    }
}
