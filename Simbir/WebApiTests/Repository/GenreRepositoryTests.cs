using Domain.Data;
using FluentAssertions;
using Repository.Repositories;
using System;
using System.Linq;
using Xunit;

namespace WebApiTests.Repository
{
    [Collection("DatabaseCollection")]
    public class GenreRepositoryTests
    {
        private readonly DatabaseFixture _database;
        private readonly GenreRepository _repository;

        public GenreRepositoryTests(DatabaseFixture fixture)
        {
            _database = fixture;
            var context = _database.CreateContext();
            _repository = new GenreRepository(context);
        }

        [Fact]
        public void GetGenre_WithExistGenre_ShouldReturn_Genre()
        {
            //Arrange
            var expected = _database.GenreEntity.First();

            //Act
            var actual = _repository.Get(1);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllGenres_WithExistGenre_ShouldReturn_ListGenre()
        {
            //Arrange
            var expected = _database.GenreEntity.ToList();

            //Act
            var actual = _repository.GetAll();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void InsertGenre_WithExistGenre_ShouldReturn_Genre()
        {
            //Arrange
            var expected = new Genre
            {
                Id = 3,
                GenreName = "Приключение"
            };

            //Act
            _repository.Insert(expected);
            var actual = _database.GenreEntity.First(Genre => Genre.Id == 3);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void DeleteGenre_WithExistGenre()
        {
            //Arrange
            var expected = _database.GenreEntity.First();

            //Act
            _repository.Remove(expected);

            //Assert
            Assert.Single(_database.GenreEntity.AsEnumerable());
        }

        [Fact]
        public void UpdateGenre_WithExistGenre_ShouldReturn_Genre()
        {
            //Arrange
            var expected = _database.GenreEntity.First();
            expected.GenreName = "Научиная литература";

            //Act
            _repository.Update(expected);
            var actual = _database.GenreEntity.First();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetGenre_WithNoExistGenre__ShouldReturn_Exception()
        {
            //Arrange

            //Act
            Action act = () => _repository.Get(4);

            //Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("User with Id 4 not found", exception.Message);
        }

        [Fact]
        public void GetAllGenres_WithNoExistGenre_ShouldReturn_Empty()
        {
            //Arrange
            foreach (var Genre in _database.GenreEntity.AsEnumerable())
            {
                _repository.Remove(Genre);
            }

            //Act
            var actual = _repository.GetAllGenres();

            //Assert
            actual.Should().BeEmpty();
        }

        [Fact]
        public void InsertGenre_WithNoExistGenre_ShouldReturn_ArgumentNullException()
        {
            //Arrange

            //Act
            Action act = () => _repository.Insert(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void DeleteGenre_WithNoExistGenre_ShouldReturn_ArgumentNullException()
        {
            //Arrange

            //Act
            Action act = () => _repository.Remove(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void UpdateGenre_WithNoExistGenre_ShouldReturn_ArgumentNullException()
        {
            //Arrange

            //Act
            Action act = () => _repository.Update(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
