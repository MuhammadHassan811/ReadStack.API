
using ReadStack.API.Persistence;
using ReadStack.Application.Models;
using ReadStack.Application.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace ReadStack.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksControllers : ControllerBase
    {
        private readonly IBooksServices _services;

        public BooksControllers(IBooksServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            var results = _services.GetAll(search);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _services.GetById(id);

            if (result is null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBookInputModel model)
        {
            var result = _services.Post(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _services.Delete(id);

            if (result is null)
            {
                return BadRequest(result);
            }

            return Ok();
        }
    }
}