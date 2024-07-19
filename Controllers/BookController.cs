using Caso_Di_Studio.Data;
using Caso_Di_Studio.Entities;
using Caso_Di_Studio.Repository;
using Caso_Di_Studio.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
            try
            {
                var books = await _bookService.GetAll();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore nel recupero dei libri.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _bookService.DeleteBook(id);
                if (!result)
                {
                    return NotFound("Libro non trovato.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore durante la cancellazione del libro.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("I dati del libro non sono validi.");
            }

            try
            {
                await _bookService.InsertBook(book);
                return CreatedAtAction(nameof(GetAll), new { id = book.Id }, book);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore durante l'inserimento del libro.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore generico durante l'inserimento del libro.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("I dati del libro non sono validi.");
            }

            try
            {
                var updatedBook = await _bookService.UpdateBook(book);
                if (updatedBook == null)
                {
                    return NotFound("Libro non trovato.");
                }
                return Ok(updatedBook);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore durante l'aggiornamento del libro.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Errore generico durante l'aggiornamento del libro.");
            }
        }
    }
}
