using Microsoft.AspNetCore.Mvc;
using simulacro1.DTOs.Editorials;
using simulacro1.Services;

namespace simulacro1.Controllers.Editorials
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class EditorialsUpdateStatusController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IEditorialsRepository _editorialsRepository;
        public EditorialsUpdateStatusController(IEditorialsRepository editorialsRepository){
            _editorialsRepository = editorialsRepository;
        }

        [HttpPatch]
        [Route("api/editorials/updateStatus/{id}")]
        public IActionResult UpdateStatus(int id, [FromBody] EditorialStatusUpdateDTO editorialDTO)
        {
            if (editorialDTO == null || string.IsNullOrEmpty(editorialDTO.Status))
            {
                return BadRequest("Invalid data.");
            }

            var editorial = _editorialsRepository.GetById(id);

            if (editorial == null)
            {
                return NotFound();
            }

            // Solo actualizar el campo Status
            if (editorialDTO.Status.ToLower() != "active" && editorialDTO.Status.ToLower() != "inactive")
            {
                return BadRequest("Status must be 'active' or 'inactive'.");
            }

            editorial.Status = editorialDTO.Status;

            _editorialsRepository.Update(editorial);

            return Ok(editorial);
        }
    }
}