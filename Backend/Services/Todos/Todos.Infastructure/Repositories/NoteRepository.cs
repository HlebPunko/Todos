using Todos.Domain.Entities;
using Todos.Infastructure.Context;
using Todos.Infastructure.Repositories.Interfaces;

namespace Todos.Infastructure.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(TodosDbContext context) : base(context)
        {
        }
    }
}
