using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.AuthDtos;
using Twitter.Business.Dtos.TopicDtos;
using Twitter.Business.Exceptions.AppUser;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
    public class UserService : IUserService
    {
        UserManager<AppUser> _userManager {  get; }
        IMapper _mapper {  get; }
        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task CreateAsync(RegisterDto dto)
        {
            AppUser user = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new ();
                foreach (var item in result.Errors)
                {
                    sb.Append(item.Description + " ");
                }
                throw new AppUserCreatedFailedException(sb.ToString());
            }
        }
        IEnumerable<UserListItemDto> IUserService.GetAll()
            => _mapper.Map<IEnumerable<UserListItemDto>>(_userManager.Users);
    }
}
