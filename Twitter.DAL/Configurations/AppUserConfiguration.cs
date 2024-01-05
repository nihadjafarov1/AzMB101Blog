using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Core.Entities;

namespace Twitter.DAL.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
