using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Business.Dtos.TopicDtos;
using Twitter.Business.Exceptions.Common;
using Twitter.Business.Exceptions.Topic;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
    public class PostService : IPostService
    {
        IPostRepository _repo { get; }
        IHttpContextAccessor _contextAccessor { get; }
        IMapper _mapper { get; }
        UserManager<AppUser> _userManager { get; }
        readonly string userId;
        public PostService(IPostRepository repo, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager, IMapper mapper)
        {
            _repo = repo;
            _contextAccessor = contextAccessor;
            userId = _contextAccessor.HttpContext?.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value ?? throw new ArgumentNullException(nameof(userId));
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task CreateAsync(PostCreateDto dto)
        {
            await _repo.CreateAsync(new Post
            {
                AppUserId = userId,
                Content = dto.Content,
            });
            await _repo.SaveAsync();
        }
        public IEnumerable<PostListItemDto> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<PostListItemDto>>(data);
        }

        public async Task RemoveAsync(int id)
        {
            var data = await _checkId(id);
            _repo.Remove(data);
            await _repo.SaveAsync();
        }
        public async Task UpdateAsync(int id, PostUpdateDto dto)
        {
            var data = await _checkId(id);
            if (dto.Content.ToLower() != data.Content.ToLower())
            {
                if (await _repo.IsExistAsync(r => r.Content.ToLower() == dto.Content.ToLower()))
                    throw new TopicExistException();
                data = _mapper.Map(dto, data);
                await _repo.SaveAsync();
            }
        }
        async Task<Post> _checkId(int id, bool isTrack = false)
        {
            if (id <= 0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id, isTrack);
            if (data == null) throw new NotFoundException<Topic>();
            return data;
        }
    }
}
