using simulacro1.Models;

namespace simulacro1.Services
{
    public interface IAuthorsRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task<IEnumerable<Author>> GetAllInactive();
        Task<Author> GetById(int id);
        void Add(Author author);
        void Update(Author author);
    }
}