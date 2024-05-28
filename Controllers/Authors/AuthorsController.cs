using Microsoft.AspNetCore.Mvc;
using simulacro1.Models;
using simulacro1.Services;

namespace simulacro1.Controllers.Authors
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class AuthorsController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IAuthorsRepository _authorsRepository;
        public AuthorsController(AuthorsRepository authorsRepository){
            _authorsRepository = authorsRepository;
        }

        [HttpPost]
        [Route("api/author/create")]
        public IActionResult Create([FromBody] Author author){
            _authorsRepository.Add(author);
            return Ok(author);
        }
    }
}