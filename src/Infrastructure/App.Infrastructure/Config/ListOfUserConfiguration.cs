using Application.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Infrastructure.Config
{
    public class ListOfUserConfiguration : IEntityTypeConfiguration<ListOfUser>
    {
        public void Configure(EntityTypeBuilder<ListOfUser> builder)
        {
            //builder.Property(x => x.ListName).IsRequired().HasMaxLength(100);
            //builder.Property(x => x.Description).IsRequired().HasMaxLength(200);

            //builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            //builder.HasMany(x => x.Items).WithOne().HasForeignKey(x => x.Id);

        }
    }
}
