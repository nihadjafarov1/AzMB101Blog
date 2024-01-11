using AutoMapper;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Core.Entities;

namespace Twitter.Business.Profiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Post,PostListItemDto>();
            CreateMap<PostUpdateDto,Post>();
            CreateMap<PostCreateDto,Post>();
        }
    }
}
