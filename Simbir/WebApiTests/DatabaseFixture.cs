//using Domain.Data;
//using Microsoft.Data.Sqlite;
//using Microsoft.EntityFrameworkCore;
//using Repository;
//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace WebApiTests
//{
//    [CollectionDefinition("DatabaseCollection")]
//    public class DatabaseCollection : ICollectionFixture<DatabaseFixture> { }

//    public class DatabaseFixture : IDisposable
//    {
//        private static readonly object _lock = new object();
//        private static bool _databaseInitialized;
//        public SqliteConnection Connection { get; }

//        public DatabaseFixture()
//        {
//            Connection = new SqliteConnection("Filename=:memory:");

//            Seed();

//            Connection.Open();
//        }

//        public DataContext CreateContext(DbTransaction transaction = null)
//        {
//            var context = new DataContext(new DbContextOptionsBuilder<DataContext>().UseSqlite(Connection).Options);

//            if (transaction != null)
//            {
//                context.Database.UseTransaction(transaction);
//            }

//            return context;
//        }

//        private void Seed()
//        {
//            lock (_lock)
//            {
//                if (!_databaseInitialized)
//                {
//                    using (var context = CreateContext())
//                    {
//                        context.Database.EnsureDeleted();
//                        context.Database.EnsureCreated();

//                        var author = new Author
//                        {
//                            Id = 1,
//                            FirstName = "Александр",
//                            MiddleName = "Сергеевич",
//                            LastName = "Пушкин",
//                            Books = new List<Book>()

//                        };
//                        var book = new Book
//                        {
//                            Id = 1,
//                            Title = "Евгений Онегин",
//                            AuthorId = 1,
//                            YearOfWriting = 1830,
//                            Genres = new List<Genre>(),
//                            Humans = new List<Human>()
//                        };
//                        var genre = new Genre
//                        {
//                            Id = 1,
//                            GenreName = "Роман",
//                            Books = new List<Book>()
//                        };
//                        var human = new Human
//                        {
//                            FirstName = "Руслан",
//                            LastName = "Козляк",
//                            MiddleName = "Владимирович",
//                            Birthday = "14.08.2001",
//                            Books = new List<Book>()
//                        };

//                        author.Books.Add(book);
//                        human.Books.Add(book);
//                        book.Genres.Add(genre);
//                        book.Author = author;

//                        context.AddRange(author, book, genre, human);

//                        context.SaveChanges();
//                    }
//                    _databaseInitialized = true;
//                }
//            }
//        }
//        public void Dispose() => Connection.Dispose();
//    }

//}
