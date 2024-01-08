using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.AuthDtos;
using Twitter.Core.Entities;

namespace Twitter.Business.Profiles
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserListItemDto>();
        }
    }
}
