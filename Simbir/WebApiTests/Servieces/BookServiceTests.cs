
using AutoMapper;
using Domain.Data;
using Domain.DTO.AuthorDtos;
using Domain.DTO.BookDtos;
using Domain.DTO.GenreDtos;
using Domain.DTO.HumanDtos;
using Domain.RepositoryInterfaces;
using Moq;
using Service;
using Service.Mapping;
using System.Collections.Generic;
using Xunit;

namespace WebApiTests.Servieces
{
   public class BookServiceTests
    {
        private static IMapper _mapper;

        public BookServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AuthorMap());
                    mc.AddProfile(new BookMap());
                    mc.AddProfile(new GenreMap());
                    mc.AddProfile(new HumanMap());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void GetBook_WithExistBook_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            var mock = new Mock<IRepository<Book>>();
            var service = new BookService(mock.Object, _mapper);
            var book = new Book
            {
                Id = 1,
                Title = "Евгений Онегин",
                AuthorId = 1,
                YearOfWriting = 1830,
                Genres = new List<Genre>(),
                Humans = new List<Human>()
            };
            var genre = new Genre
            {
                Id = 1,
                GenreName = "Роман",
                Books = new List<Book>()
            };
            var author = new Author
            {
                Id = 1,
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин",
                Books = new List<Book>()

            };
            book.Genres.Add(genre);
            book.Author = author;
            mock.Setup(repo => repo.Get(1, include => include.Author, include => include.Genres)).Returns(book);
            var expected = new BookWithAuthorAndGenreDto
            {
                Title = "Евгений Онегин",
                YearOfWriting = 1830,
                Genres = new List<GenreWithoutBooksDto>(),
            };
            var genreDto = new GenreWithoutBooksDto
            {
                GenreName = "Роман"
            };
            var authorDto = new AuthorWithoutBooksDto
            {
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин"
            };
            expected.Genres.Add(genreDto);
            expected.Author = authorDto;

            var actual = service.GetBook(1);

            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.YearOfWriting, actual.YearOfWriting);
            Assert.Equal(expected.Author.FirstName, actual.Author.FirstName);
            Assert.Equal(expected.Author.LastName, actual.Author.LastName);
            Assert.Equal(expected.Author.MiddleName, actual.Author.MiddleName);
            Assert.Equal(expected.Genres[0].GenreName, actual.Genres[0].GenreName);
        }

        [Fact]
        public void GetAllBooks_WithExistbooks_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            var mock = new Mock<IRepository<Book>>();
            var service = new BookService(mock.Object, _mapper);
            var book = new Book
            {
                Id = 1,
                Title = "Евгений Онегин",
                AuthorId = 1,
                YearOfWriting = 1830,
                Genres = new List<Genre>(),
                Humans = new List<Human>()
            };
            var genre = new Genre
            {
                Id = 1,
                GenreName = "Роман",
                Books = new List<Book>()
            };
            var author = new Author
            {
                Id = 1,
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин",
                Books = new List<Book>()

            };
            book.Genres.Add(genre);
            book.Author = author;
            var books = new List<Book>();
            books.Add(book);
            mock.Setup(repo => repo.GetAll(include => include.Author, include => include.Genres)).Returns(books);
            var expected = new BookWithAuthorAndGenreDto
            {
                Title = "Евгений Онегин",
                YearOfWriting = 1830,
                Genres = new List<GenreWithoutBooksDto>(),
            };
            var genreDto = new GenreWithoutBooksDto
            {
                GenreName = "Роман"
            };
            var authorDto = new AuthorWithoutBooksDto
            {
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин"
            };
            expected.Genres.Add(genreDto);
            expected.Author = authorDto;

            var actualBooks = service.GetAllBooks();
            var actual = new List<BookWithAuthorAndGenreDto>();
            foreach (var a in actualBooks)
                actual.Add(a);

            Assert.Equal(expected.Title, actual[0].Title);
            Assert.Equal(expected.YearOfWriting, actual[0].YearOfWriting);
            Assert.Equal(expected.Author.FirstName, actual[0].Author.FirstName);
            Assert.Equal(expected.Author.LastName, actual[0].Author.LastName);
            Assert.Equal(expected.Author.MiddleName, actual[0].Author.MiddleName);
            Assert.Equal(expected.Genres[0].GenreName, actual[0].Genres[0].GenreName);
        }

        [Fact]
        public void GetAuthorBooks_WithExistbooks_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            var mock = new Mock<IRepository<Book>>();
            var service = new BookService(mock.Object, _mapper);
            var book = new Book
            {
                Id = 1,
                Title = "Евгений Онегин",
                AuthorId = 1,
                YearOfWriting = 1830,
                Genres = new List<Genre>(),
                Humans = new List<Human>()
            };
            var genre = new Genre
            {
                Id = 1,
                GenreName = "Роман",
                Books = new List<Book>()
            };
            var author = new Author
            {
                Id = 1,
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин",
                Books = new List<Book>()

            };
            book.Genres.Add(genre);
            book.Author = author;
            var books = new List<Book>();
            books.Add(book);
            mock.Setup(repo => repo.GetAll(include => include.Author, include => include.Genres)).Returns(books);
            var expected = new BookWithAuthorAndGenreDto
            {
                Title = "Евгений Онегин",
                YearOfWriting = 1830,
                Genres = new List<GenreWithoutBooksDto>(),
            };
            var genreDto = new GenreWithoutBooksDto
            {
                GenreName = "Роман"
            };
            var authorDto = new AuthorWithoutBooksDto
            {
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин"
            };
            expected.Genres.Add(genreDto);
            expected.Author = authorDto;

            var actualBooks = service.GetAuthorBooks(1);
            var actual = new List<BookWithAuthorAndGenreDto>();
            foreach (var a in actualBooks)
                actual.Add(a);

            Assert.Equal(expected.Title, actual[0].Title);
            Assert.Equal(expected.YearOfWriting, actual[0].YearOfWriting);
            Assert.Equal(expected.Author.FirstName, actual[0].Author.FirstName);
            Assert.Equal(expected.Author.LastName, actual[0].Author.LastName);
            Assert.Equal(expected.Author.MiddleName, actual[0].Author.MiddleName);
            Assert.Equal(expected.Genres[0].GenreName, actual[0].Genres[0].GenreName);
        }

        [Fact]
        public void GetByAuthorQuery_WithExistbooks_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            var mock = new Mock<IRepository<Book>>();
            var service = new BookService(mock.Object, _mapper);
            var book = new Book
            {
                Id = 1,
                Title = "Евгений Онегин",
                AuthorId = 1,
                YearOfWriting = 1830,
                Genres = new List<Genre>(),
                Humans = new List<Human>()
            };
            var genre = new Genre
            {
                Id = 1,
                GenreName = "Роман",
                Books = new List<Book>()
            };
            var author = new Author
            {
                Id = 1,
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин",
                Books = new List<Book>()

            };
            book.Genres.Add(genre);
            book.Author = author;
            var books = new List<Book>();
            books.Add(book);
            mock.Setup(repo => repo.GetAll(include => include.Author, include => include.Genres)).Returns(books);
            var expected = new BookWithAuthorAndGenreDto
            {
                Title = "Евгений Онегин",
                YearOfWriting = 1830,
                Genres = new List<GenreWithoutBooksDto>(),
            };
            var genreDto = new GenreWithoutBooksDto
            {
                GenreName = "Роман"
            };
            var authorDto = new AuthorWithoutBooksDto
            {
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин"
            };
            expected.Genres.Add(genreDto);
            expected.Author = authorDto;

            var actualBooks = service.GetByAuthorQuery("Пушкин");
            var actual = new List<BookWithAuthorAndGenreDto>();
            foreach (var a in actualBooks)
                actual.Add(a);

            Assert.Equal(expected.Title, actual[0].Title);
            Assert.Equal(expected.YearOfWriting, actual[0].YearOfWriting);
            Assert.Equal(expected.Author.FirstName, actual[0].Author.FirstName);
            Assert.Equal(expected.Author.LastName, actual[0].Author.LastName);
            Assert.Equal(expected.Author.MiddleName, actual[0].Author.MiddleName);
            Assert.Equal(expected.Genres[0].GenreName, actual[0].Genres[0].GenreName);
        }

        [Fact]
        public void GetByGenreQuery_WithExistbooks_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            var mock = new Mock<IRepository<Book>>();
            var service = new BookService(mock.Object, _mapper);
            var book = new Book
            {
                Id = 1,
                Title = "Евгений Онегин",
                AuthorId = 1,
                YearOfWriting = 1830,
                Genres = new List<Genre>(),
                Humans = new List<Human>()
            };
            var genre = new Genre
            {
                Id = 1,
                GenreName = "Роман",
                Books = new List<Book>()
            };
            var author = new Author
            {
                Id = 1,
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин",
                Books = new List<Book>()

            };
            book.Genres.Add(genre);
            book.Author = author;
            var books = new List<Book>();
            books.Add(book);
            mock.Setup(repo => repo.GetAll(include => include.Author, include => include.Genres)).Returns(books);
            var expected = new BookWithAuthorAndGenreDto
            {
                Title = "Евгений Онегин",
                YearOfWriting = 1830,
                Genres = new List<GenreWithoutBooksDto>(),
            };
            var genreDto = new GenreWithoutBooksDto
            {
                GenreName = "Роман"
            };
            var authorDto = new AuthorWithoutBooksDto
            {
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин"
            };
            expected.Genres.Add(genreDto);
            expected.Author = authorDto;

            var actualBooks = service.GetByGenreQuery("Роман");
            var actual = new List<BookWithAuthorAndGenreDto>();
            foreach (var a in actualBooks)
                actual.Add(a);

            Assert.Equal(expected.Title, actual[0].Title);
            Assert.Equal(expected.YearOfWriting, actual[0].YearOfWriting);
            Assert.Equal(expected.Author.FirstName, actual[0].Author.FirstName);
            Assert.Equal(expected.Author.LastName, actual[0].Author.LastName);
            Assert.Equal(expected.Author.MiddleName, actual[0].Author.MiddleName);
            Assert.Equal(expected.Genres[0].GenreName, actual[0].Genres[0].GenreName);
        }

        [Fact]
        public void GetBookByYear_WithExistbooks_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            var mock = new Mock<IRepository<Book>>();
            var service = new BookService(mock.Object, _mapper);
            var book = new Book
            {
                Id = 1,
                Title = "Евгений Онегин",
                AuthorId = 1,
                YearOfWriting = 1830,
                Genres = new List<Genre>(),
                Humans = new List<Human>()
            };
            var genre = new Genre
            {
                Id = 1,
                GenreName = "Роман",
                Books = new List<Book>()
            };
            var author = new Author
            {
                Id = 1,
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин",
                Books = new List<Book>()

            };
            book.Genres.Add(genre);
            book.Author = author;
            var books = new List<Book>();
            books.Add(book);
            mock.Setup(repo => repo.GetAll(include => include.Author, include => include.Genres)).Returns(books);
            var expected = new BookWithAuthorAndGenreDto
            {
                Title = "Евгений Онегин",
                YearOfWriting = 1830,
                Genres = new List<GenreWithoutBooksDto>(),
            };
            var genreDto = new GenreWithoutBooksDto
            {
                GenreName = "Роман"
            };
            var authorDto = new AuthorWithoutBooksDto
            {
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин"
            };
            expected.Genres.Add(genreDto);
            expected.Author = authorDto;

            var actualBooks = service.GetBookByYear(1830,true);
            var actual = new List<BookWithAuthorAndGenreDto>();
            foreach (var a in actualBooks)
                actual.Add(a);

            Assert.Equal(expected.Title, actual[0].Title);
            Assert.Equal(expected.YearOfWriting, actual[0].YearOfWriting);
            Assert.Equal(expected.Author.FirstName, actual[0].Author.FirstName);
            Assert.Equal(expected.Author.LastName, actual[0].Author.LastName);
            Assert.Equal(expected.Author.MiddleName, actual[0].Author.MiddleName);
            Assert.Equal(expected.Genres[0].GenreName, actual[0].Genres[0].GenreName);
        }
    }
}
