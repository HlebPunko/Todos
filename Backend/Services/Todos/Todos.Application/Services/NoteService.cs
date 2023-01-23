using AutoMapper;
using Todos.Application.Models.NoteModels;
using Todos.Application.Services.Interfaces;
using Todos.Domain.Entities;
using Todos.Infastructure.Repositories.Interfaces;

namespace Todos.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        
        public NoteService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<List<ViewNoteModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var notes = await _manager.NoteRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<List<ViewNoteModel>>(notes);
        }

        public async Task<ViewNoteModel> GetAsync(int id, CancellationToken cancellationToken)
        {
            if (id is default(int))
            {
                throw new ArgumentException("Id have default value!");
            }

            var note = await _manager.NoteRepository.GetAsync(id, cancellationToken);

            if (note is null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            return _mapper.Map<ViewNoteModel>(note);
        }

        public async Task<List<ViewNoteModel>> GetNotesByNoteBookIdAsync(int noteBookId, CancellationToken cancellationToken)
        {
            if(noteBookId is default(int))
            {
                throw new ArgumentException("Notebook id have default value!");
            }

            var allNotes = await _manager.NoteRepository.GetAllAsync(cancellationToken);

            var result = allNotes.Where(x => x.NoteBookId == noteBookId).ToList();

            if(result is null)
            {
                throw new ArgumentNullException("This Notebook don`t have any notes!");
            }

            return _mapper.Map<List<ViewNoteModel>>(result); 
        }

        public async Task<ViewNoteModel> CreateAsync(CreateNoteModel model, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Note>(model);

            var createdNote = await _manager.NoteRepository.CreateAsync(map, cancellationToken);

            if (createdNote is null)
            {
                throw new ArgumentNullException(nameof(createdNote));
            }

            await _manager.SaveAsync(cancellationToken);

            return _mapper.Map<ViewNoteModel>(createdNote);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            if (id is default(int))
            {
                throw new ArgumentException("Id have default value!");
            }

            var note = await _manager.NoteRepository.GetAsync(id, cancellationToken);

            if (note is null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            await _manager.NoteRepository.DeleteAsync(note, cancellationToken);

            await _manager.SaveAsync(cancellationToken);
        }

        public async Task<ViewNoteModel> UpdateAsync(UpdateNoteModel model, CancellationToken cancellationToken)
        {
            if (model.Id is default(int))
            {
                throw new ArgumentException("Id have default value!");
            }

            var map = _mapper.Map<Note>(model);

            var updatedNote = await _manager.NoteRepository.UpdateAsync(map, cancellationToken);

            if (updatedNote is null)
            {
                throw new ArgumentNullException(nameof(updatedNote));
            }

            await _manager.SaveAsync(cancellationToken);

            return _mapper.Map<ViewNoteModel>(updatedNote);
        }
    }
}
