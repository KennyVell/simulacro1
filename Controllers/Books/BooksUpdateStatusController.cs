using Microsoft.AspNetCore.Mvc;
using simulacro1.DTO.Books;
using simulacro1.Services;

namespace simulacro1.Controllers.Books
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class BooksUpdateStatusController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IBooksRepository _booksRepository;
        public BooksUpdateStatusController(IBooksRepository booksRepository){
            _booksRepository = booksRepository;
        }

        [HttpPatch]
        [Route("api/books/updateStatus/{id}")]
        public IActionResult UpdateStatus(int id, [FromBody] BookStatusUpdateDTO bookDTO)
        {
            if (bookDTO == null || string.IsNullOrEmpty(bookDTO.Status))
            {
                return BadRequest("Invalid data.");
            }

            var book = _booksRepository.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            // Solo actualizar el campo Status
            if (bookDTO.Status.ToLower() != "active" && bookDTO.Status.ToLower() != "inactive")
            {
                return BadRequest("Status must be 'active' or 'inactive'.");
            }

            book.Status = bookDTO.Status;

            _booksRepository.Update(book);

            return Ok(book);
        }
    }
}