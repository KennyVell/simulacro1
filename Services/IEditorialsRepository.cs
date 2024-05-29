using simulacro1.Models;

namespace simulacro1.Services
{
    public interface IEditorialsRepository
    {
        object editorials { get; }

        Task<IEnumerable<Editorial>> GetAll();
        Task<IEnumerable<Editorial>> GetAllInactive();
        Task<Editorial> GetById(int id);
        void Add(Editorial editorial);
        void Update(Editorial editorial);       
    }
}