using AutoMapper;
using Twitter.Business.Dtos.CommentDtos;
using Twitter.Core.Entities;

namespace Twitter.Business.Profiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, CommentListItemDto>();
            CreateMap<CommentCreateDto, Comment>();
        }
    }
}
