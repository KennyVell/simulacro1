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
            .Where(a => a.Status.ToLower() == "active").ToList();

            return activeAuthors;
        }

        public IEnumerable<Author> GetAllInactive()
        {
            var inactiveAuthors = _context.Authors
            .Where(a => a.Status.ToLower() == "inactive").ToList();

            return inactiveAuthors;
        }

        public Author GetById(int id)
        {
            return _context.Authors.Find(id);
        }

        public void Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }
}