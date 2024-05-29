using Microsoft.EntityFrameworkCore;
using simulacro1.Data;
using simulacro1.Models;

namespace simulacro1.Services
{
    public class BooksRepository : IBooksRepository
    {
        public readonly BaseContext _context;
        
        public BooksRepository(BaseContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var activeBooks = await _context.Books
            .Include(b => b.Author).Include(b => b.Editorial)
            .Where(b => b.Status.ToLower() == "active").ToListAsync();

            return activeBooks;
        }

        public async Task<IEnumerable<Book>> GetAllInactive()
        {
            var activeBooks = await _context.Books
            .Include(b => b.Author).Include(b => b.Editorial)
            .Where(b => b.Status.ToLower() == "inactive").ToListAsync();

            return activeBooks;
        }

        public async Task<Book> GetById(int id)
        {
            var book = await _context.Books
            .Include(b => b.Author).Include(b => b.Editorial)
            .FirstOrDefaultAsync(a => a.Id == id);
            return book;
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}