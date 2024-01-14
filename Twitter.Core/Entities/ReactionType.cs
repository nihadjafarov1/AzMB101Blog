namespace Twitter.Core.Entities
{
    public class ReactionType : BaseEntity
    {
        public string Content { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
