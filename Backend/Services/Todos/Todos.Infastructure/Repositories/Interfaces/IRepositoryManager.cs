namespace Todos.Infastructure.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        INoteBookRepository NoteBookRepository { get; }
        INoteRepository NoteRepository{ get; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
