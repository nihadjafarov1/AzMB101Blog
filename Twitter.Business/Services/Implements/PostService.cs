using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
    public class PostService : IPostService
    {
        IPostRepository _repo {  get; }
        IHttpContextAccessor _contextAccessor { get; }
        UserManager<AppUser> _userManager { get; }
        readonly string userId;
        public PostService(IPostRepository repo, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _repo = repo;
            _contextAccessor = contextAccessor;
            userId = _contextAccessor.HttpContext?.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value ?? throw new ArgumentNullException(nameof(userId));
            _userManager = userManager;
        }

        public async Task Create(PostCreateDto dto)
        {
            await _repo.CreateAsync(new Post
            {
                AppUserId = userId,
                Content = dto.Content,
            });
            await _repo.SaveAsync();
        }
    }
}
