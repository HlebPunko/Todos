using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todos.Domain.Entities;

namespace Todos.Infastructure.Configurations
{
    public class NoteBookConfiguration : IEntityTypeConfiguration<NoteBook>
    {
        public void Configure(EntityTypeBuilder<NoteBook> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.NoteBookTitle).IsRequired().HasMaxLength(50);

            builder.Property(x => x.NoteBookTitle).IsRequired();
        }
    }
}
