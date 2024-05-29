using Microsoft.AspNetCore.Mvc;
using simulacro1.Models;
using simulacro1.Services;

namespace simulacro1.Controllers.Authors
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class AuthorsCreateController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IAuthorsRepository _authorsRepository;
        public AuthorsCreateController(IAuthorsRepository authorsRepository){
            _authorsRepository = authorsRepository;
        }

        [HttpPost]
        [Route("api/authors/create")]
        public IActionResult Create([FromBody] Author author){
            _authorsRepository.Add(author);
            return Ok(author);
        }
    }
}