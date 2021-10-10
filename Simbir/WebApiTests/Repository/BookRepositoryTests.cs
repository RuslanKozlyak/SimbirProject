using Domain.Data;
using FluentAssertions;
using Repository.Repositories;
using System;
using System.Linq;
using Xunit;

namespace WebApiTests.Repository
{
    [Collection("DatabaseCollection")]
    public class BookRepositoryTests
    {
        private readonly DatabaseFixture _database;
        private readonly BookRepository _repository;

        public BookRepositoryTests(DatabaseFixture fixture)
        {
            _database = fixture;
            var context = _database.CreateContext();
            _repository = new BookRepository(context);
        }

        [Fact]
        public void GetBook_WithExistBook_ShouldReturn_Book()
        {
            //Arrange
            var expected = _database.BookEntity.First();

            //Act
            var actual = _repository.Get(1);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllBooks_WithExistBook_ShouldReturn_ListBook()
        {
            //Arrange
            var expected = _database.BookEntity.ToList();

            //Act
            var actual = _repository.GetAll();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void InsertBook_WithExistBook_ShouldReturn_Book()
        {
            //Arrange
            var expected = new Book
            {
                Id = 3,
                Title = "Три товарища",
                AuthorId = 1,
                YearOfWriting = 1936
            };

            //Act
            _repository.Insert(expected);
            var actual = _database.BookEntity.First(Book => Book.Id == 3);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void DeleteBook_WithExistBook()
        {
            //Arrange
            var expected = _database.BookEntity.First();

            //Act
            _repository.Remove(expected);

            //Assert
            Assert.Single(_database.BookEntity.AsEnumerable());
        }

        [Fact]
        public void UpdateBook_WithExistBook_ShouldReturn_Book()
        {
            //Arrange
            var expected = _database.BookEntity.First();
            expected.Title = "Чистая архитектура";

            //Act
            _repository.Update(expected);
            var actual = _database.BookEntity.First();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetBook_WithNoExistBook_ShouldReturn_Exception()
        {
            //Arrange

            //Act
            Action act = () => _repository.Get(4);

            //Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("User with Id 4 not found", exception.Message);
        }

        [Fact]
        public void GetAllBooks_WithNoExistBook_ShouldReturn_Empty()
        {
            //Arrange
            foreach (var Book in _database.BookEntity.AsEnumerable())
            {
                _repository.Remove(Book);
            }

            //Act
            var actual = _repository.GetAllBooks();

            //Assert
            actual.Should().BeEmpty();
        }

        [Fact]
        public void InsertBook_WithNoExistBook_ShouldReturn_ArgumentNullException()
        {
            //Arrange

            //Act
            Action act = () => _repository.Insert(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void DeleteBook_WithNoExistBook_ShouldReturn_ArgumentNullException()
        {
            //Arrange

            //Act
            Action act = () => _repository.Remove(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void UpdateBook_WithNoExistBook_ShouldReturn_ArgumentNullException()
        {
            //Arrange

            //Act
            Action act = () => _repository.Update(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
