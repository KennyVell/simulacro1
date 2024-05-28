using Microsoft.AspNetCore.Mvc;
using simulacro1.Models;
using simulacro1.Services;

namespace simulacro1.Controllers.Books
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class BooksController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IBooksRepository _booksRepository;
        public BooksController(BooksRepository booksRepository){
            _booksRepository = booksRepository;
        }
        
        [HttpPost]
        [Route("api/book/create")]
        public IActionResult Create([FromBody] Book book){
            _booksRepository.Add(book);
            return Ok(book);
        }
    }
}