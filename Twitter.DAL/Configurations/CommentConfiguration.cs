using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Core.Entities;

namespace Twitter.DAL.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(512);

            builder.HasOne(x => x.ParentComment)
                .WithMany(e => e.ChildComments)
                .HasForeignKey(e => e.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AppUser)
                .WithMany(u => u.Comments)
                .HasForeignKey(u => u.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Post)
                .WithMany(u => u.Comments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
