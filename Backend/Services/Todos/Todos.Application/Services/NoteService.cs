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
            var orders = await _manager.NoteRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<List<ViewNoteModel>>(orders);
        }

        public async Task<ViewNoteModel> GetAsync(int id, CancellationToken cancellationToken)
        {
            if (id is default(int))
            {
                throw new ArgumentException("Id have default value!");
            }

            var order = await _manager.NoteRepository.GetAsync(id, cancellationToken);

            if (order is null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            return _mapper.Map<ViewNoteModel>(order);
        }

        public async Task<ViewNoteModel> CreateAsync(CreateNoteModel model, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Note>(model);

            var createdOrder = await _manager.NoteRepository.CreateAsync(map, cancellationToken);

            if (createdOrder is null)
            {
                throw new ArgumentNullException(nameof(createdOrder));
            }

            await _manager.SaveAsync(cancellationToken);

            return _mapper.Map<ViewNoteModel>(createdOrder);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            if (id is default(int))
            {
                throw new ArgumentException("Id have default value!");
            }

            var order = await _manager.NoteRepository.GetAsync(id, cancellationToken);

            if (order is null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            await _manager.NoteRepository.DeleteAsync(order, cancellationToken);

            await _manager.SaveAsync(cancellationToken);
        }

        public async Task<ViewNoteModel> UpdateAsync(UpdateNoteModel model, CancellationToken cancellationToken)
        {
            if (model.Id is default(int))
            {
                throw new ArgumentException("Id have default value!");
            }

            var map = _mapper.Map<Note>(model);

            var updatedOrder = await _manager.NoteRepository.UpdateAsync(map, cancellationToken);

            if (updatedOrder is null)
            {
                throw new ArgumentNullException(nameof(updatedOrder));
            }

            await _manager.SaveAsync(cancellationToken);

            return _mapper.Map<ViewNoteModel>(updatedOrder);
        }
    }
}
