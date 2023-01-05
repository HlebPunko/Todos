namespace Todos.Domain.Entities
{
    public class NoteBook
    {
        public int Id { get; set; }
        public string NoteBookTitle { get; set; } = null!;
        public List<Note> Notes { get; set; } = null!;
    }
}
