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
        public async Task<IActionResult> Get(){
            return Ok(await _booksRepository.GetAll());
        }

        [HttpGet]
        [Route("api/books/{id}")]
        public async Task<IActionResult> Get(int id){
            return Ok(await _booksRepository.GetById(id));
        }
    }
}