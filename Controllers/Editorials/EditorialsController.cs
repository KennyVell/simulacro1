using Microsoft.AspNetCore.Mvc;
using simulacro1.Models;
using simulacro1.Services;

namespace simulacro1.Controllers.Editorials
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class EditorialsController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IEditorialsRepository _editorialsRepository;
        public EditorialsController(IEditorialsRepository editorialsRepository){
            _editorialsRepository = editorialsRepository;
        }
        
        [HttpGet]
        [Route("api/editorials")]
        public async Task<IActionResult> GetEditorials(){
            return Ok(await _editorialsRepository.GetAll());
        }

        [HttpGet]
        [Route("api/editorials/{id}")]
        public async Task<IActionResult> Details(int id){
            return Ok(await _editorialsRepository.GetById(id));
        }
    }
}