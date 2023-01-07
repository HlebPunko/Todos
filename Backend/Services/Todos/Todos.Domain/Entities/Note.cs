namespace Todos.Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string NoteTitle { get; set; } = null!;
        public string NoteBody { get; set; } = null!;
        public DateTimeOffset WhenAdded { get; set; }
        public int NoteBookId { get; set; }
        public NoteBook NoteBook { get; set; } = null!;
    }
}
