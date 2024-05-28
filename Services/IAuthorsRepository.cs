using simulacro1.Models;

namespace simulacro1.Services
{
    public interface IAuthorsRepository
    {
        IEnumerable<Author> GetAll();
        Author GetById(int id);
        void Add(Author author);
        void Update(Author author);
        void Delete(Author author);
    }
}