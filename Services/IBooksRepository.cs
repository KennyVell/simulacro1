using simulacro1.Models;

namespace simulacro1.Services
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}