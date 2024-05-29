using Microsoft.AspNetCore.Mvc;
using simulacro1.DTO.Authors;
using simulacro1.Services;

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
        [Route("api/authors/update/{id}")]
        public IActionResult Update(int id, [FromBody] AuthorDTO authorDTO)
        {
            // Validación del DTO
            if (authorDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            // Obtener el autor existente
            var author = _authorsRepository.GetById(id);

            if (author == null)
            {
                return NotFound();
            }

            // Actualizar solo las propiedades que han cambiado
            bool isUpdated = false;

            if (!string.IsNullOrEmpty(authorDTO.Name) && author.Name != authorDTO.Name)
            {
                author.Name = authorDTO.Name;
                isUpdated = true;
            }

            if (!string.IsNullOrEmpty(authorDTO.LastName) && author.LastName != authorDTO.LastName)
            {
                author.LastName = authorDTO.LastName;
                isUpdated = true;
            }

            if (!string.IsNullOrEmpty(authorDTO.Email) && author.Email != authorDTO.Email)
            {
                author.Email = authorDTO.Email;
                isUpdated = true;
            }

            if (!string.IsNullOrEmpty(authorDTO.Nationality) && author.Nationality != authorDTO.Nationality)
            {
                author.Nationality = authorDTO.Nationality;
                isUpdated = true;
            }
            //el status
            if (!string.IsNullOrEmpty(authorDTO.Status) && author.Status!= authorDTO.Status)
            {
                author.Status = authorDTO.Status;
                isUpdated = true;
            }


            // Si no hay cambios, devolver un NoContent
            if (!isUpdated)
            {
                return NoContent();
            }

            // Guardar los cambios en el repositorio
            _authorsRepository.Update(author);

            return Ok(author);
        }
    }
}