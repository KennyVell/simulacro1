using Microsoft.AspNetCore.Mvc;
using simulacro1.Models;
using simulacro1.Services;

namespace simulacro1.Controllers.Books
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class BooksUpdateController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IBooksRepository _booksRepository;
        public BooksUpdateController(BooksRepository booksRepository){
            _booksRepository = booksRepository;
        }

        [HttpPut]
        [Route("api/books/update")]
        public IActionResult Update([FromBody] Book book){
            _booksRepository.Update(book);
            return Ok(book);
        }
    }
}