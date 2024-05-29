using simulacro1.Models;

namespace simulacro1.Services
{
    public interface IEditorialsRepository
    {
        object editorials { get; }

        IEnumerable<Editorial> GetAll();
        Editorial GetById(int id);
        void Add(Editorial editorial);
        void Update(Editorial editorial);       
    }
}