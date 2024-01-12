using Twitter.Business.Dtos.AppUserDtos;

namespace Twitter.Business.Dtos.CommentDtos
{
    public class CommentListItemDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
        public AppUserInPostItemDto AppUser { get; set; }
        public int ParentCommentId { get; set; }
    }
}
