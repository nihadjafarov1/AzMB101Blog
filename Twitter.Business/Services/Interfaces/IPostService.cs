using Twitter.Business.Dtos.PostDtos;

namespace Twitter.Business.Services.Interfaces
{
    public interface IPostService
    {
        Task Create(PostCreateDto dto);
    }
}
