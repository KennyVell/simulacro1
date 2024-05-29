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
        public AuthorsController(IAuthorsRepository authorsRepository){
            _authorsRepository = authorsRepository;
        }

        [HttpGet]
        [Route("api/authors")]
        public IActionResult Get(){
            return Ok(_authorsRepository.GetAll());
        }

        [HttpGet]
        [Route("api/authors/{id}")]
        public IActionResult Get(int id){
            return Ok(_authorsRepository.GetById(id));
        }
    }
}