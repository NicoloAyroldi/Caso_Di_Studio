using Caso_Di_Studio.Data;
using Microsoft.AspNetCore.Mvc;

namespace Caso_Di_Studio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DataContext _context;

        public BookController(DataContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }
        
    }
}

