using Caso_Di_Studio.Data;
using Caso_Di_Studio.Entities;
using Caso_Di_Studio.Repository;
using Caso_Di_Studio.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caso_Di_Studio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAll();
            return Ok(books);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.DeleteBook(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> InsertBook([FromBody] Book book){
            await _bookService.InsertBook(book);
            return Ok(book);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            var UpdatedBook = await _bookService.UpdateBook(book);
            if(UpdatedBook == null){
                return NotFound();
            }
            return Ok(UpdatedBook);
            
        }
    }
}

