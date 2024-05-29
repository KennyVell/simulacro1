using Microsoft.AspNetCore.Mvc;
using simulacro1.DTO;
using simulacro1.Models;
using simulacro1.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;

namespace simulacro1.Controllers.Authors
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class AuthorsUpdateController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IAuthorsRepository _authorsRepository;
        public AuthorsUpdateController(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        [HttpPatch]
        [Route("api/authors/update")]
        public IActionResult Update(int id, [FromBody] JsonPatchDocument<AuthorDTO> patchDoc)
        {
            var author = _authorsRepository.GetById(id);

            if (author == null)
            {
                return NotFound();
            }

            var authorDTO = new AuthorDTO
            {
                Name = author.Name,
                LastName = author.LastName,
                Email = author.Email,
                Nationality = author.Nationality
            };

            patchDoc.ApplyTo(authorDTO);

            author.Name = authorDTO.Name;
            author.LastName = authorDTO.LastName;
            author.Email = authorDTO.Email;
            author.Nationality = authorDTO.Nationality;

            _authorsRepository.Update(author);

            return Ok(author);
        }
    }
}