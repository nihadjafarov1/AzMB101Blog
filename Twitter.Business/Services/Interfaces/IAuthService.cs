using Twitter.Business.Dtos.AuthDtos;
using Twitter.Business.Dtos.TopicDtos;

namespace Twitter.Business.Services.Interfaces
{
    public interface IAuthService
    {
        public IEnumerable<UserListItemDto> GetAll();
        public Task<UserDetailDto> GetByUsernameAsync(int id);
        public Task RegisterAsync(RegisterDto dto);
    }
}
