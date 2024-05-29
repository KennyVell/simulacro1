using Microsoft.AspNetCore.Mvc;
using simulacro1.Models;
using simulacro1.Services;

namespace simulacro1.Controllers.Books
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class BooksCreateController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IBooksRepository _booksRepository;
        public BooksCreateController(IBooksRepository booksRepository){
            _booksRepository = booksRepository;
        }

        [HttpPost]
        [Route("api/books/create")]
        public IActionResult Create([FromBody] Book book){
            _booksRepository.Add(book);
            return Ok(book);
        }
    }
}