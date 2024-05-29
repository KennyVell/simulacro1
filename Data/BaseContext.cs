using Microsoft.EntityFrameworkCore;
using simulacro1.Models;

namespace simulacro1.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Editorial> Editorials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la relación uno a muchos entre Author y Book
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId); // Asegúrate de que AuthorId sea la clave foránea en la tabla Book

            // Configurar la relación uno a muchos entre Editorial y Book
            modelBuilder.Entity<Editorial>()
                .HasMany(e => e.Books)
                .WithOne(b => b.Editorial)
                .HasForeignKey(b => b.EditorialId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)             // Un libro pertenece a un autor
                .WithMany(a => a.Books)            // Un autor puede tener muchos libros
                .HasForeignKey(b => b.AuthorId);  // Clave foránea para la relación entre Book y Author

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Editorial)         // Un libro pertenece a una editorial
                .WithMany(e => e.Books)            // Una editorial puede tener muchos libros
                .HasForeignKey(b => b.EditorialId);
        }
    }
}