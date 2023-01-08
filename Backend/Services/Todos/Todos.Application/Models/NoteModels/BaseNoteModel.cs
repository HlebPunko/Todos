namespace Todos.Application.Models.NoteModels
{
    public abstract class BaseNoteModel
    {
        public string NoteTitle { get; set; } = null!;
        public string NoteBody { get; set; } = null!;
        public int NoteBookId { get; set; }
    }
}
