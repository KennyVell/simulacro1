using Microsoft.AspNetCore.Mvc;
using simulacro1.Models;
using simulacro1.Services;

namespace simulacro1.Controllers.Authors
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class AuthorsUpdateController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IAuthorsRepository _authorsRepository;
        public AuthorsUpdateController(IAuthorsRepository authorsRepository){
            _authorsRepository = authorsRepository;
        }

        [HttpPut]
        [Route("api/authors/update")]
        public IActionResult Update([FromBody] Author author){
            _authorsRepository.Update(author);
            return Ok(author);
        }
    }
}