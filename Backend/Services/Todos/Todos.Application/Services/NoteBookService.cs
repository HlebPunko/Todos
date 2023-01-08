using AutoMapper;
using Todos.Application.Models.NoteBookModels;
using Todos.Application.Services.Interfaces;
using Todos.Domain.Entities;
using Todos.Infastructure.Repositories.Interfaces;

namespace Todos.Application.Services
{
    public class NoteBookService : INoteBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public NoteBookService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<List<ViewNoteBookModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var orders = await _manager.NoteBookRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<List<ViewNoteBookModel>>(orders);
        }

        public async Task<ViewNoteBookModel> GetAsync(int id, CancellationToken cancellationToken)
        {
            if (id is default(int))
            {
                throw new ArgumentException("Id have default value!");
            }

            var order = await _manager.NoteBookRepository.GetAsync(id, cancellationToken);

            if (order is null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            return _mapper.Map<ViewNoteBookModel>(order);
        }

        public async Task<ViewNoteBookModel> CreateAsync(CreateNoteBookModel model, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<NoteBook>(model);

            var createdOrder = await _manager.NoteBookRepository.CreateAsync(map, cancellationToken);

            if (createdOrder is null)
            {
                throw new ArgumentNullException(nameof(createdOrder));
            }

            await _manager.SaveAsync(cancellationToken);

            return _mapper.Map<ViewNoteBookModel>(createdOrder);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            if (id is default(int))
            {
                throw new ArgumentException("Id have default value!");
            }

            var order = await _manager.NoteBookRepository.GetAsync(id, cancellationToken);

            if (order is null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            await _manager.NoteBookRepository.DeleteAsync(order, cancellationToken);

            await _manager.SaveAsync(cancellationToken);
        }

        public async Task<ViewNoteBookModel> UpdateAsync(UpdateNoteBookModel model, CancellationToken cancellationToken)
        {
            if (model.Id is default(int))
            {
                throw new ArgumentException("Id have default value!");
            }

            var map = _mapper.Map<NoteBook>(model);

            var updatedOrder = await _manager.NoteBookRepository.UpdateAsync(map, cancellationToken);

            if (updatedOrder is null)
            {
                throw new ArgumentNullException(nameof(updatedOrder));
            }

            await _manager.SaveAsync(cancellationToken);

            return _mapper.Map<ViewNoteBookModel>(updatedOrder);
        }
    }
}
