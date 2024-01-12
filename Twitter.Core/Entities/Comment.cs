namespace Twitter.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public int? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public List<Comment>? ChildComments { get; set; }
    }
}
