using Microsoft.AspNetCore.Mvc;
using simulacro1.Models;
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

        [HttpPut]
        [Route("api/editorials/update")]
        public IActionResult Update([FromBody] Editorial editorial){
            _editorialsRepository.Update(editorial);
            return Ok(editorial);
        }
    }
}