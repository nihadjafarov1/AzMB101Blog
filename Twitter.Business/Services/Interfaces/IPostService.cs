using Twitter.Business.Dtos.PostDtos;
using Twitter.Business.Dtos.TopicDtos;

namespace Twitter.Business.Services.Interfaces
{
    public interface IPostService
    {
        public IEnumerable<PostListItemDto> GetAll();
        //public Task<TopicDetailDto> GetByIdAsync(int id);
        public Task CreateAsync(PostCreateDto dto);
        public Task RemoveAsync(int id);
        public Task UpdateAsync(int id, PostUpdateDto dto);
    }
}
