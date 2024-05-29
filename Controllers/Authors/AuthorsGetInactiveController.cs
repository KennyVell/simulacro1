using Microsoft.AspNetCore.Mvc;
using simulacro1.Services;

namespace simulacro1.Controllers.Authors
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class AuthorsGetInactiveController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IAuthorsRepository _authorsRepository;
        public AuthorsGetInactiveController(IAuthorsRepository authorsRepository){
            _authorsRepository = authorsRepository;
        }

        [HttpGet]
        [Route("api/authors/inactive")] 
        public IActionResult GetInactive(){
            return Ok(_authorsRepository.GetAllInactive());
        }
    }
}