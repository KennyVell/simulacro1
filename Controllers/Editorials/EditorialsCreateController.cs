using Microsoft.AspNetCore.Mvc;
using simulacro1.Models;
using simulacro1.Services;

namespace simulacro1.Controllers.Editorials
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class EditorialsCreateController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IEditorialsRepository _editorialsRepository;
        public EditorialsCreateController(IEditorialsRepository editorialsRepository){
            _editorialsRepository = editorialsRepository;
        }
        
        [HttpPost]
        [Route("api/editorials/create")]
        public IActionResult Create([FromBody] Editorial editorial){
            _editorialsRepository.Add(editorial);
            return Ok(editorial);
        }
    }
}