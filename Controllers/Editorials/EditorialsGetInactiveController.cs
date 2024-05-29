using Microsoft.AspNetCore.Mvc;
using simulacro1.Services;

namespace simulacro1.Controllers.Authors
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class EditorialsGetInactiveController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IEditorialsRepository _editorialsRepository;
        public EditorialsGetInactiveController(IEditorialsRepository editorialsRepository){
            _editorialsRepository = editorialsRepository;
        }

        [HttpGet]
        [Route("api/editorials/inactive")] 
        public async Task<IActionResult> Get(){
            return Ok(_editorialsRepository.GetAllInactive());
        }
    }
}