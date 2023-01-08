using Todos.Application.Models.NoteBookModels;

namespace Todos.Application.Services.Interfaces
{
    public interface INoteBookService
    {
        Task<List<ViewNoteBookModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<ViewNoteBookModel> GetAsync(int id, CancellationToken cancellationToken);
        Task<ViewNoteBookModel> CreateAsync(CreateNoteBookModel model, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<ViewNoteBookModel> UpdateAsync(UpdateNoteBookModel model, CancellationToken cancellationToken);
    }
}
