using simulacro1.Models;

namespace simulacro1.Services
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<IEnumerable<Book>> GetAllInactive();
        Task<Book> GetById(int id);
        void Add(Book book);
        void Update(Book book);
    }
}