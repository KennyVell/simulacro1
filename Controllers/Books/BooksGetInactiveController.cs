using Microsoft.AspNetCore.Mvc;
using simulacro1.Services;

namespace simulacro1.Controllers.Authors
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class BooksGetInactiveController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IBooksRepository _booksRepository;
        public BooksGetInactiveController(IBooksRepository booksRepository){
            _booksRepository = booksRepository;
        }

        [HttpGet]
        [Route("api/books/inactive")] 
        public async Task<IActionResult> Get(){
            return Ok(_booksRepository.GetAllInactive());
        }
    }
}