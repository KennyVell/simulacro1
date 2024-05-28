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

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(Book book)
        {
            throw new NotImplementedException();
        }
    }
}