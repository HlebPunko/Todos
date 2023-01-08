namespace Todos.Application.Models.NoteModels
{
    public class ViewNoteModel : BaseNoteModel
    {
        public DateTimeOffset WhenAdded { get; set; }
    }
}
