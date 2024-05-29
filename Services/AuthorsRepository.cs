using Microsoft.EntityFrameworkCore;
using System.Linq;
using simulacro1.Data;
using simulacro1.Models;


namespace simulacro1.Services
{
    public class AuthorsRepository : IAuthorsRepository
    {
        public readonly BaseContext _context;

        public AuthorsRepository(BaseContext context)
        {
            _context = context;
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public IEnumerable<Author> GetAll()
        {
            var activeAuthors = _context.Authors
            .Include(a => a.Books) // Incluye los libros relacionados con cada autor
            .Where(a => a.Status.ToLower() == "active").ToList();

            return activeAuthors;
        }

        public IEnumerable<Author> GetAllInactive()
        {
            var inactiveAuthors = _context.Authors
            .Include(a => a.Books)
            .Where(a => a.Status.ToLower() == "inactive").ToList();

            return inactiveAuthors;
        }

        public async Task<Author> GetById(int id)
        {
            var author = await _context.Authors
            .Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
            return author;
        }

        public void Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }
}