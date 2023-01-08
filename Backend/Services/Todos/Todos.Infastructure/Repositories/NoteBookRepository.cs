using Todos.Domain.Entities;
using Todos.Infastructure.Context;
using Todos.Infastructure.Repositories.Interfaces;

namespace Todos.Infastructure.Repositories
{
    public class NoteBookRepository : BaseRepository<NoteBook>, INoteBookRepository
    {
        public NoteBookRepository(TodosDbContext context) : base(context)
        {

        }
    }
}
