using Domain.Data;
using FluentAssertions;
using Repository.Repositories;
using System;
using System.Linq;
using Xunit;

namespace WebApiTests.Repository
{
    [Collection("DatabaseCollection")]
    public class HumanRepositoryTests
    {
        private readonly DatabaseFixture _database;
        private readonly HumanRepository _repository;

        public HumanRepositoryTests(DatabaseFixture fixture)
        {
            _database = fixture;
            var context = _database.CreateContext();
            _repository = new HumanRepository(context);
        }

        [Fact]
        public void GetHuman_WithExistHuman_ShouldReturn_Human()
        {
            //Arrange
            var expected = _database.HumanEntity.First();

            //Act
            var actual = _repository.Get(1);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllHumans_WithExistHuman_ShouldReturn_ListHuman()
        {
            //Arrange
            var expected = _database.HumanEntity.ToList();

            //Act
            var actual = _repository.GetAll();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void InsertHuman_WithExistHuman_ShouldReturn_Human()
        {
            //Arrange
            var expected = new Human
            {
                Id = 3,
                FirstName = "Эренст",
                LastName = "Хэмингуэй"
            };

            //Act
            _repository.Insert(expected);
            var actual = _database.HumanEntity.First(Human => Human.Id == 3);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void DeleteHuman_WithExistHuman()
        {
            //Arrange
            var expected = _database.HumanEntity.First();

            //Act
            _repository.Remove(expected);

            //Assert
            Assert.Single(_database.HumanEntity.AsEnumerable());
        }

        [Fact]
        public void UpdateHuman_WithExistHuman_ShouldReturn_Human()
        {
            //Arrange
            var expected = _database.HumanEntity.First();
            expected.FirstName = "Петр";

            //Act
            _repository.Update(expected);
            var actual = _database.HumanEntity.First();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetHuman_WithNoExistHuman_ShouldReturn_Exception()
        {
            //Arrange

            //Act
            Action act = () => _repository.Get(4);

            //Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("User with Id 4 not found", exception.Message);
        }

        [Fact]
        public void GetAllHumans_WithNoExistHuman_ShouldReturn_Empty()
        {
            //Arrange
            foreach (var human in _database.HumanEntity.AsEnumerable())
            {
                _repository.Remove(human);
            }

            //Act
            var actual = _repository.GetAllHumans();

            //Assert
            actual.Should().BeEmpty();
        }

        [Fact]
        public void InsertHuman_WithNoExistHuman_ShouldReturn_ArgumentNullException()
        {
            //Arrange

            //Act
            Action act = () => _repository.Insert(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void DeleteHuman_WithNoExistHuman_ShouldReturn_ArgumentNullException()
        {
            //Arrange

            //Act
            Action act = () => _repository.Remove(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void UpdateHuman_WithNoExistHuman_ShouldReturn_ArgumentNullException()
        {
            //Arrange

            //Act
            Action act = () => _repository.Update(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
