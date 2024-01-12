using Twitter.Business.Dtos.CommentDtos;
using Twitter.Business.Dtos.PostDtos;

namespace Twitter.Business.Services.Interfaces
{
    public interface ICommentService
    {
        public Task Create(CommentCreateDto dto);
        public IEnumerable<CommentListItemDto> Get();
        public Task Delete();

    }
}
