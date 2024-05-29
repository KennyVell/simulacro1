using Microsoft.AspNetCore.Mvc;
using simulacro1.Services;

namespace simulacro1.Controllers.Authors
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class AuthorsController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IAuthorsRepository _authorsRepository;
        public AuthorsController(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        [HttpGet]
        [Route("api/authors")]
        public async Task<IActionResult> GetActive()
        {
            return Ok( await _authorsRepository.GetAll());
        }

        [HttpGet]
        [Route("api/authors/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await _authorsRepository.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

    }
}