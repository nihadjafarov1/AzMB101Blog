using AutoMapper;
using Twitter.Business.Dtos.CommentDtos;
using Twitter.Business.Dtos.TopicDtos;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;

namespace Twitter.Business.Services.Implements
{
    public class CommentService : ICommentService
    {
        ICommentRepository _repo { get; }
        IMapper _mapper {  get; }

        public CommentService(ICommentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task Create(CommentCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentListItemDto> Get()
            => _mapper.Map<IEnumerable<CommentListItemDto>>(_repo.GetAll());
    }
}
