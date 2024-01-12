namespace Twitter.Business.Dtos.CommentDtos
{
    public class CommentCreateDto
    {
        public string Content { get; set; }
        public int ParentCommentId { get; set; }
    }
}
