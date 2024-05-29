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

        public async Task<IEnumerable<Author>> GetAll()
        {
            var activeAuthors = await _context.Authors
            .Include(a => a.Books) // Incluye los libros relacionados con cada autor
            .Where(a => a.Status.ToLower() == "active").ToListAsync();

            return activeAuthors;
        }

        public async Task<IEnumerable<Author>> GetAllInactive()
        {
            var inactiveAuthors = await _context.Authors
            .Include(a => a.Books)
            .Where(a => a.Status.ToLower() == "inactive").ToListAsync();

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