namespace Todos.Domain.Entities
{
    public class NoteBook : BaseEntity
    {
        public string NoteBookTitle { get; set; } = null!;
        public List<Note> Notes { get; set; } = null!;
    }
}
