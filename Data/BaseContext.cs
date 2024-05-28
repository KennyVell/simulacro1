using Microsoft.EntityFrameworkCore;
using simulacro1.Models;

namespace simulacro1.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options){}

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Editorial> Editorials { get; set; }
    }
}