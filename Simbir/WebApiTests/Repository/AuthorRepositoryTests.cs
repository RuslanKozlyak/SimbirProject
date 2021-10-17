using Domain.Data;
using FluentAssertions;
using Repository.Repositories;
using System;
using System.Linq;
using Xunit;

namespace WebApiTests.Repository
{
    [Collection("DatabaseCollection")]
    public class AuthorRepositoryTests
    {
        private readonly DatabaseFixture _database;
        private readonly AuthorRepository _repository;

        public AuthorRepositoryTests(DatabaseFixture fixture)
        {
            _database = fixture;
            var context = _database.CreateContext();
            _repository = new AuthorRepository(context);
        }

        [Fact]
        public void GetAuthor_WithExistAuthor_ShouldReturn_Author()
        {
            //Arrange
            var expected = _database.AuthorEntity.First();

            //Act
            var actual = _repository.Get(1);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllAuthors_WithExistAuthor_ShouldReturn_ListAuthor()
        {
            //Arrange
            var expected = _database.AuthorEntity.ToList();

            //Act
            var actual = _repository.GetAll();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void InsertAuthor_WithExistAuthor_ShouldReturn_Author()
        {
            //Arrange
            var expected = new Author
            {
                Id = 3,
                FirstName = "Эренст",
                LastName = "Хэмингуэй"
            };

            //Act
            _repository.Insert(expected);
            var actual = _database.AuthorEntity.First(author => author.Id == 3);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void DeleteAuthor_WithExistAuthor()
        {
            //Arrange
            var expected = _database.AuthorEntity.First();

            //Act
            _repository.Remove(expected);

            //Assert
            Assert.Single(_database.AuthorEntity.AsEnumerable());
        }

        [Fact]
        public void UpdateAuthor_WithExistAuthor()
        {
            //Arrange
            var expected = _database.AuthorEntity.First();
            expected.FirstName = "Петр";

            //Act
            _repository.Update(expected);
            var actual = _database.AuthorEntity.First();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAuthor_WithNoExistAuthor_ShouldReturn_Exception()
        {
            //Arrange

            //Act
            Action act = () => _repository.Get(4);

            //Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("User with Id 4 not found", exception.Message);
        }

        [Fact]
        public void GetAllAuthors_WithNoExistAuthor_ShouldReturn_Empty()
        {
            //Arrange
            foreach (var author in _database.AuthorEntity.AsEnumerable())
            {
                _repository.Remove(author);
            }

            //Act
            var actual = _repository.GetAllAuthors();

            //Assert
            actual.Should().BeEmpty();
        }

        [Fact]
        public void InsertAuthor_WithNoExistAuthor_ShouldReturn_ArgumentNullException()
        {
            //Arrange

            //Act
            Action act = () => _repository.Insert(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void DeleteAuthor_WithNoExistAuthor_ShouldReturn_ArgumentNullException()
        {
            //Arrange

            //Act
            Action act = () => _repository.Remove(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void UpdateAuthor_WithNoExistAuthor_ShouldReturn_ArgumentNullException()
        {
            //Arrange

            //Act
            Action act = () => _repository.Update(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
