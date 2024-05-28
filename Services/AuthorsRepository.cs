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
    }
}