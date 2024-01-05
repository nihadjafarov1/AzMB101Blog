using AutoMapper;
using Twitter.Business.Dtos.AuthDtos;
using Twitter.Business.Dtos.TopicDtos;
using Twitter.Business.Exceptions.Topic;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        IAuthRepository _repo { get; }
        IMapper _mapper { get; }


        public AuthService(IAuthRepository repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        IEnumerable<UserListItemDto> IAuthService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<UserDetailDto> IAuthService.GetByUsernameAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IAuthService.RegisterAsync(RegisterDto dto)
        {
            await _repo.CreateAsync(_mapper.Map<AppUser>(dto));
            await _repo.SaveAsync();
        }
    }
}
