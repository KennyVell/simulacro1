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

        public void Add(Editorial editorial)
        {
            _context.Editorials.Add(editorial);
            _context.SaveChanges();
        }
    }
}