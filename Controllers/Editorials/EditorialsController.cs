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
        public EditorialsController(EditorialsRepository editorialsRepository){
            _editorialsRepository = editorialsRepository;
        }
        
        [HttpGet]
        [Route("api/editorials")]
        public IActionResult GetEditorials(){
            return Ok(_editorialsRepository.GetAll());
        }

        [HttpGet]
        [Route("api/editorials/{id}")]
        public IActionResult Details(int id){
            return Ok(_editorialsRepository.GetById(id));
        }
    }
}