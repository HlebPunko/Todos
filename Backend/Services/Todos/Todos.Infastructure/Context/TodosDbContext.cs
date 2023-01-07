using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Todos.Domain.Entities;

namespace Todos.Infastructure.Context
{
    public class TodosDbContext : DbContext
    {
        public DbSet<Note> Notes = null!;
        public DbSet<NoteBook> NoteBooks = null!;

        public TodosDbContext(DbContextOptions<TodosDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
