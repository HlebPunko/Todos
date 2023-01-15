using Microsoft.AspNetCore.Mvc;
using System.Net;
using Todos.Application.Models.NoteBookModels;
using Todos.Application.Services.Interfaces;

namespace TodosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteBooksController : ControllerBase
    {
        private readonly INoteBookService _service;

        public NoteBooksController(INoteBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetNoteBooks(CancellationToken cancellationToken)
        {
            var res = await _service.GetAllAsync(cancellationToken);

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteBook([FromRoute] int id, CancellationToken cancellationToken)
        {
            var res = await _service.GetAsync(id, cancellationToken);

            return Ok(res);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateNoteBook([FromBody] CreateNoteBookModel noteBook, CancellationToken cancellationToken)
        {
            var res = await _service.CreateAsync(noteBook, cancellationToken);

            return Ok(res);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteNoteBook([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(id, cancellationToken);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNoteBook([FromRoute] int id, [FromBody] UpdateNoteBookModel noteBook,
            CancellationToken cancellationToken)
        {
            if (id != noteBook.Id)
            {
                return BadRequest("Different Id entered!");
            }

            var res = await _service.UpdateAsync(noteBook, cancellationToken);

            return Ok(res);
        }
    }
}
