using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TinyHelpers.EntityFrameworkCore.Converters;//TODO This package will not work, because, he interaction with a lot of different versions EF Core

namespace Identity.Infastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);

            builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);

            builder.Property(u => u.DateOfBirth).IsRequired().HasConversion<DateOnlyConverter>().HasColumnType("date");
        }
    }
}
