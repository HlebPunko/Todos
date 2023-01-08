using AutoMapper;
using Todos.Application.Models.NoteBookModels;
using Todos.Application.Models.NoteModels;
using Todos.Domain.Entities;

namespace Todos.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateNoteBookModel, NoteBook>();
            CreateMap<UpdateNoteBookModel, NoteBook>();
            CreateMap<NoteBook, ViewNoteBookModel>();

            CreateMap<CreateNoteModel, Note>();
            CreateMap<UpdateNoteModel, Note>();
            CreateMap<Note, ViewNoteModel>();
        }
    }
}
