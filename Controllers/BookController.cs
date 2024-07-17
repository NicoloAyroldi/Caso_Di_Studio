using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Caso_Di_Studio.Entities;

namespace Caso_Di_Studio.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = new List<Book>(){
                new Book{
                    Id=1,
                    Titolo="Test",
                    Anno="2024",
                    Descrizione="Prova"
                }
            };
            return Ok(books);
        }
        
    }
}