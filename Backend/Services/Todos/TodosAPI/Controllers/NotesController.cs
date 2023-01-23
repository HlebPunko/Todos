using Microsoft.AspNetCore.Mvc;
using System.Net;
using Todos.Application.Models.NoteModels;
using Todos.Application.Services.Interfaces;

namespace TodosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _service;

        public NotesController(INoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes(CancellationToken cancellationToken)
        {
            var res = await _service.GetAllAsync(cancellationToken);

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNote([FromRoute] int id, CancellationToken cancellationToken)
        {
            var res = await _service.GetAsync(id, cancellationToken);

            return Ok(res);
        }

        [HttpGet($"{nameof(GetNotesByNoteBookId)}")]
        public async Task<IActionResult> GetNotesByNoteBookId( int noteBookId, CancellationToken cancellationToken)
        {
            var res = await _service.GetNotesByNoteBookIdAsync(noteBookId, cancellationToken);

            return Ok(res);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteModel note, CancellationToken cancellationToken)
        {
            var res = await _service.CreateAsync(note, cancellationToken);

            return Ok(res);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteNote([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(id, cancellationToken);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote([FromRoute] int id, [FromBody] UpdateNoteModel note,
            CancellationToken cancellationToken)
        {
            if (id != note.Id)
            {
                return BadRequest("Different Id entered!");
            }

            var res = await _service.UpdateAsync(note, cancellationToken);

            return Ok(res);
        }
    }
}
