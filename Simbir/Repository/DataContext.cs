using Data;
using Microsoft.EntityFrameworkCore;
using Data.DTO;
using Data.Mapping;

namespace Repository
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new HumanMap(modelBuilder.Entity<Human>());
            new BookMap(modelBuilder.Entity<Book>());
            new AuthorMap(modelBuilder.Entity<Author>());
            new GenreMap(modelBuilder.Entity<Genre>());
            new BookGenreMap(modelBuilder.Entity<BookGenre>());
            new LibraryCardMap(modelBuilder.Entity<LibraryCard>());
        }
    }
}
