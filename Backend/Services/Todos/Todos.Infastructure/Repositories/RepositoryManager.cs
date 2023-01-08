using Microsoft.EntityFrameworkCore.Query.Internal;
using Todos.Infastructure.Context;
using Todos.Infastructure.Repositories.Interfaces;

namespace Todos.Infastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly TodosDbContext _context;

        public RepositoryManager(TodosDbContext context)
        {
            _context = context;
        }

        public INoteBookRepository NoteBookRepository => new NoteBookRepository(_context);

        public INoteRepository NoteRepository => new NoteRepository(_context);

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
