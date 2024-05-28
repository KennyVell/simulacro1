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
    }
}