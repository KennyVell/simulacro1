using Microsoft.AspNetCore.Mvc;
using simulacro1.DTO.Authors;
using simulacro1.Services;

namespace simulacro1.Controllers.Authors
{
    // [ApiController]
    // [Route("api/[controller]")]
    public class AuthorsUpdateStatusController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IAuthorsRepository _authorsRepository;
        public AuthorsUpdateStatusController(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        [HttpPatch]
        [Route("api/authors/updateStatus/{id}")]
        public IActionResult UpdateStatus(int id, [FromBody] AuthorStatusUpdateDTO authorDTO)
        {
            if (authorDTO == null || string.IsNullOrEmpty(authorDTO.Status))
            {
                return BadRequest("Invalid data.");
            }

            var author = _authorsRepository.GetById(id);

            if (author == null)
            {
                return NotFound();
            }

            // Solo actualizar el campo Status
            if (authorDTO.Status.ToLower() != "active" && authorDTO.Status.ToLower() != "inactive")
            {
                return BadRequest("Status must be 'active' or 'inactive'.");
            }

            author.Status = authorDTO.Status;

            _authorsRepository.Update(author);

            return Ok(author);
        }
    }
}