using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todos.Domain.Entities;
using Todos.Infastructure.Context;

namespace TodosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteBookController : ControllerBase
    {
        public NoteBookController()
        {

        }

        [HttpGet]
        public IActionResult GetNoteBooks()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateNoteBook(NoteBook noteBook)
        {
            return Ok();
        }
    }
}
