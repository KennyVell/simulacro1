using Microsoft.AspNetCore.Mvc;
using simulacro1.DTOs.Books;
using simulacro1.Services;

namespace simulacro1.Controllers.Books
{
    /* [ApiController]
    [Route("api/[controller]")] */
    public class BooksUpdateController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly IBooksRepository _booksRepository;
        public BooksUpdateController(IBooksRepository booksRepository){
            _booksRepository = booksRepository;
        }

        [HttpPatch]
        [Route("api/books/update/{id}")]
         public IActionResult Update(int id, [FromBody] BookDTO bookDTO)
        {
            // Validación del DTO
            if (bookDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            // Obtener el book existente
            var book = _booksRepository.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            // Actualizar solo las propiedades que han cambiado
            bool isUpdated = false;

            if (bookDTO.Title!= null)
            {
                book.Title = bookDTO.Title;
                isUpdated = true;
            }
            if (bookDTO.Pages!= 0)
            {
                book.Pages = bookDTO.Pages;
                isUpdated = true;
            }
            if (bookDTO.Language!= null)
            {
                book.Language = bookDTO.Language;
                isUpdated = true;
            }
            if (bookDTO.PublicationDate!= DateTime.MinValue)
            {
                book.PublicationDate = bookDTO.PublicationDate;
                isUpdated = true;
            }
            if (bookDTO.Description!= null)
            {
                book.Description = bookDTO.Description;
                isUpdated = true;
            }
            // el status
            if (bookDTO.Status!= null)
            {
                book.Status = bookDTO.Status;
                isUpdated = true;
            }           
            // los ids
            if (bookDTO.AuthorId!= 0)
            {
                book.AuthorId = bookDTO.AuthorId;
                isUpdated = true;
            }
            if (bookDTO.EditorialId!= 0)
            {
                book.EditorialId = bookDTO.EditorialId;
                isUpdated = true;
            }

            // Si no hay cambios, devolver un NoContent
            if (!isUpdated)
            {
                return NoContent();
            }

            // Guardar los cambios en el repositorio
            _booksRepository.Update(book);

            return Ok(book);
        }

    }
}