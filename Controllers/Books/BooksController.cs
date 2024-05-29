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
        public BooksController(IBooksRepository booksRepository){
            _booksRepository = booksRepository;
        }
        
        [HttpGet]
        [Route("api/books")]
        public IActionResult Get(){
            return Ok(_booksRepository.GetAll());
        }

        [HttpGet]
        [Route("api/books/{id}")]
        public IActionResult Get(int id){
            return Ok(_booksRepository.GetById(id));
        }
    }
}