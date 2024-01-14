using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Twitter.Business.Dtos.CommentDtos;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
    public class CommentService : ICommentService
    {
        ICommentRepository _repo { get; }
        IMapper _mapper {  get; }
        IHttpContextAccessor _contextAccessor { get; }
        readonly string userId;

        public CommentService(ICommentRepository repo, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _repo = repo;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            userId = _contextAccessor.HttpContext?.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value ?? throw new ArgumentNullException(nameof(userId));
        }

        public async Task CreateAsync(CommentCreateDto dto)
        {
            await _repo.CreateAsync(new Comment
            {
                AppUserId = userId,
                Content = dto.Content,
                ParentCommentId = dto.ParentCommentId,
                PostId = dto.PostId,
            });
            await _repo.SaveAsync();
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentListItemDto> Get()
        {
            var data = _repo.GetAll(true, "AppUser");
            return _mapper.Map<IEnumerable<CommentListItemDto>>(data);
        }
    }
}
