using Domain.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace WebApiTests
{
    public class DatabaseFixture : IDisposable
    {
        public DbSet<Author> AuthorEntity;
        public DbSet<Book> BookEntity;
        public DbSet<Genre> GenreEntity;
        public DbSet<Human> HumanEntity;
        private DbConnection _connection;

        private DbContextOptions<DataContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<DataContext>()
                .UseSqlite(_connection).Options;
        }

        public DataContext CreateContext()
        {
            Dispose();

            _connection = new SqliteConnection("DataSource=:memory:");

            _connection.Open();

            var options = CreateOptions();
            var context = new DataContext(options);

            context.Database.EnsureCreated();

            AuthorEntity = context.Set<Author>();
            BookEntity = context.Set<Book>();
            GenreEntity = context.Set<Genre>();
            HumanEntity = context.Set<Human>();

            Seed(context);

            return context;
        }

        private void Seed(DataContext context)
        {
            var author1 = new Author
            {
                Id = 1,
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин",
                Books = new List<Book>(),
            };
            var author2 = new Author
            {
                Id = 2,
                FirstName = "Михаил",
                MiddleName = "Афанасьевич",
                LastName = "Булгаков",
                Books = new List<Book>(),
            };

            var book1 = new Book
            {
                Id = 1,
                Title = "Евгений Онегин",
                AuthorId = 1,
                YearOfWriting = 1830,
                Genres = new List<Genre>(),
                Humans = new List<Human>()
            };
            var book2 = new Book
            {
                Id = 2,
                Title = "Мастер и Маргарита",
                AuthorId = 2,
                YearOfWriting = 1966,
                Genres = new List<Genre>(),
                Humans = new List<Human>()
            };

            var genre1 = new Genre
            {
                Id = 1,
                GenreName = "Роман",
                Books = new List<Book>()
            };
            var genre2 = new Genre
            {
                Id = 2,
                GenreName = "Сатира",
                Books = new List<Book>()
            };

            var human1 = new Human
            {
                Id = 1,
                FirstName = "Петр",
                LastName = "Петров",
                MiddleName = "Петровчи",
                Birthday = "31.12.1990",
                Books = new List<Book>()
            };
            var human2 = new Human
            {
                Id = 2,
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = "Иванович",
                Birthday = "01.01.1990",
                Books = new List<Book>()
            };

            author1.Books.Add(book1);
            author2.Books.Add(book2);

            book1.Author = author1;
            book2.Author = author2;
            book1.Genres.Add(genre1);
            book2.Genres.Add(genre2);
            book1.Humans.Add(human1);
            book2.Humans.Add(human2);

            genre1.Books.Add(book1);
            genre2.Books.Add(book2);

            human1.Books.Add(book1);
            human2.Books.Add(book2);

            AuthorEntity.AddRange(author1, author2);
            BookEntity.AddRange(book1, book2);
            GenreEntity.AddRange(genre1, genre2);
            HumanEntity.AddRange(human1, human2);

            context.SaveChanges();
        }

        public void Dispose()
        {
            if (_connection == null)
            {
                return;
            }
            _connection.Dispose();
            _connection = null;
        }
    }
}
