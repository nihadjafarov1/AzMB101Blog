using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Core.Entities;

namespace Twitter.DAL.Configurations
{
    public class ReactionTypeConfiguration : IEntityTypeConfiguration<ReactionType>
    {
        public void Configure(EntityTypeBuilder<ReactionType> builder)
        {
            builder.Property(r => r.Content)
                .IsRequired()
                .HasMaxLength(64);
            builder.HasOne(r => r.Comment)
                .WithMany(c => c.ReactionTypes)
                .HasForeignKey(r => r.CommentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
