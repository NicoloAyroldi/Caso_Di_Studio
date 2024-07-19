using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;
using Caso_Di_Studio.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caso_Di_Studio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _AuthorService;
        public AuthorController(IAuthorService authorService)
        {
            _AuthorService = authorService;
        }

         [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var author = await _AuthorService.GetAll();
            return Ok(author);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _AuthorService.DeleteAuthor(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> InsertAuthor([FromBody] Author author){
            await _AuthorService.InsertAuthor(author);
            return Ok(author);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(Author author)
        {
            var UpdatedAuthor = await _AuthorService.UpdateAuthor(author);
            if(UpdatedAuthor == null){
                return NotFound();
            }
            return Ok(UpdatedAuthor);
        }

    }
}