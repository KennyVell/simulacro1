using simulacro1.Data;
using simulacro1.Models;

namespace simulacro1.Services
{
    public class EditorialsRepository : IEditorialsRepository
    {
        public readonly BaseContext _context;
        
        public EditorialsRepository(BaseContext context)
        {
            _context = context;
        }

        public object editorials => throw new NotImplementedException();

        public void Add(Editorial editorial)
        {
            _context.Editorials.Add(editorial);
            _context.SaveChanges();
        }

        public IEnumerable<Editorial> GetAll()
        {
            return _context.Editorials.ToList();
        }

        public Editorial GetById(int id)
        {
            return _context.Editorials.Find(id);
        }

        public void Update(Editorial editorial)
        {
            _context.Editorials.Update(editorial);
            _context.SaveChanges();
        }

        public void Delete(Editorial editorial)
        {
            throw new NotImplementedException();
        }
    }
}