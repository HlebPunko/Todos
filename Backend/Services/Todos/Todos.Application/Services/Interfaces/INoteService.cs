using Todos.Application.Models.NoteModels;

namespace Todos.Application.Services.Interfaces
{
    public interface INoteService
    {
        Task<List<ViewNoteModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<ViewNoteModel> GetAsync(int id, CancellationToken cancellationToken);
        Task<List<ViewNoteModel>> GetNotesByNoteBookIdAsync(int noteBookId, CancellationToken cancellationToken);
        Task<ViewNoteModel> CreateAsync(CreateNoteModel model, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<ViewNoteModel> UpdateAsync(UpdateNoteModel model, CancellationToken cancellationToken);
    }
}
