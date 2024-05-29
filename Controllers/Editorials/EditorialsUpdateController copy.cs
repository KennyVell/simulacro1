using Microsoft.AspNetCore.Mvc;
using simulacro1.DTO.Editorials;
using simulacro1.Services;

namespace simulacro1.Controllers.Editorials
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class EditorialsUpdateController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IEditorialsRepository _editorialsRepository;
        public EditorialsUpdateController(IEditorialsRepository editorialsRepository){
            _editorialsRepository = editorialsRepository;
        }

        [HttpPatch]
        [Route("api/editorials/update/{id}")]            
        public IActionResult Update(int id, [FromBody] EditorialDTO editorialDTO)
        {
            // Validación del DTO
            if (editorialDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            // Obtener el editorial existente
            var editorial = _editorialsRepository.GetById(id);

            if (editorial == null)
            {
                return NotFound();
            }

            // Actualizar solo las propiedades que han cambiado
            bool isUpdated = false;

            if (!string.IsNullOrEmpty(editorialDTO.Name) && editorial.Name != editorialDTO.Name)
            {
                editorial.Name = editorialDTO.Name;
                isUpdated = true;
            }
            if (!string.IsNullOrEmpty(editorialDTO.Address) && editorial.Address!= editorialDTO.Address)
            {
                editorial.Address = editorialDTO.Address;
                isUpdated = true;
            }
            if (!string.IsNullOrEmpty(editorialDTO.Phone) && editorial.Phone!= editorialDTO.Phone)
            {
                editorial.Phone = editorialDTO.Phone;
                isUpdated = true;
            }
            if (!string.IsNullOrEmpty(editorialDTO.Email) && editorial.Email!= editorialDTO.Email)
            {
                editorial.Email = editorialDTO.Email;
                isUpdated = true;
            }
            if (!string.IsNullOrEmpty(editorialDTO.Status) && editorial.Status!= editorialDTO.Status)
            {
                editorial.Status = editorialDTO.Status;
                isUpdated = true;
            }

            // Si no hay cambios, devolver un NoContent
            if (!isUpdated)
            {
                return NoContent();
            }

            // Guardar los cambios en el repositorio
            _editorialsRepository.Update(editorial);

            return Ok(editorial);
        }
    }
}