using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todos.Domain.Entities;

namespace Todos.Infastructure.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.NoteTitle).IsRequired().HasMaxLength(50);

            builder.Property(x => x.NoteBody).IsRequired().HasMaxLength(500);

            builder.Property(x => x.WhenAdded).IsRequired().ValueGeneratedOnAdd();
        }
    }
}
