using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<IEnumerable<Editorial>> GetAll()
        {
            var activeEditorials = await _context.Editorials
            .Include(e => e.Books) // Incluye los libros relacionados con cada autor
            .Where(e => e.Status.ToLower() == "active").ToListAsync();

            return activeEditorials;
        }

        public async Task<IEnumerable<Editorial>> GetAllInactive()
        {
            var inactiveEditorials = await _context.Editorials
            .Include(a => a.Books)
            .Where(a => a.Status.ToLower() == "inactive").ToListAsync();

            return inactiveEditorials;
        }

        public async Task<Editorial> GetById(int id)
        {
            var editorial = await _context.Editorials
            .Include(e => e.Books).FirstOrDefaultAsync(e => e.Id == id);
            return editorial;
        }

        public void Update(Editorial editorial)
        {
            _context.Editorials.Update(editorial);
            _context.SaveChanges();
        }
    }
}