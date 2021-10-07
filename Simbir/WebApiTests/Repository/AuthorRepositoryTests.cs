using AutoMapper;
using Domain.Data;
using FluentAssertions;
using Repository.Repositories;
using Service.Mapping;
using System;
using System.Collections.Generic;
using Xunit;

namespace WebApiTests.RepositoryTest
{
    [Collection("DatabaseCollection")]
    public class AuthorRepositoryTests
    {
        private DatabaseFixture _database;
        private static IMapper _mapper;

        public AuthorRepositoryTests(DatabaseFixture fixture)
        {
            _database = fixture;

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
        public void GetAuthor_WithExistAuthor_ShouldReturn_Author()
        {
            //Arrange
            using var context = _database.CreateContext();
            var repository = new AuthorRepository(context);
            var expected = new Author
            {
                Id = 2,
                FirstName = "Михаил",
                MiddleName = "Афанасьевич",
                LastName = "Булгаков"
            };

            //Act
            var actual = repository.Get(2);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllAuthors_WithExistAuthor_ShouldReturn_ListAuthor()
        {
            //Arrange
            using var context = _database.CreateContext();
            var repository = new AuthorRepository(context);

            var expected = new List<Author>
                {
                    new Author
                    {
                        Id = 1,
                        FirstName = "Александр",
                        MiddleName = "Сергеевич",
                        LastName = "Пушкин"
                    },
                    new Author
                    {
                        Id = 2,
                        FirstName = "Михаил",
                        MiddleName = "Афанасьевич",
                        LastName = "Булгаков"
                    }
                };

            //Act
            var actual = repository.GetAll();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void InsertAuthor_WithExistAuthor_ShouldReturn_Exception()
        {
            //Arrange
            using var context = _database.CreateContext();
            var repository = new AuthorRepository(context);
            var expected = new Author
            {
                Id = 3,
                FirstName = "Эренст",
                LastName = "Хэмингуэй"
            };

            //Act
            repository.Insert(expected);
            var actual = repository.Get(3);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void DeleteAuthor_WithExistAuthor()
        {
            //Arrange
            using var context = _database.CreateContext();
            var repository = new AuthorRepository(context);
            var expected = repository.Get(1);
            //Act
            repository.Remove(expected);
            Action act = () => repository.Get(1);

            //Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("User with Id 1 not found", exception.Message);
        }

        [Fact]
        public void UpdateAuthor_WithExistAuthor()
        {
            //Arrange
            using var context = _database.CreateContext();
            var repository = new AuthorRepository(context);

            var expected = new Author
            {
                Id = 1,
                FirstName = "Петр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин"
            };

            //Act
            repository.Update(expected);
            var actual = repository.Get(1);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAuthor_WithNoExistAuthor_ShouldReturn_Author()
        {
            //Arrange
            using var context = _database.CreateContext();
            var repository = new AuthorRepository(context);

            //Act
            Action act = () => repository.Get(4);

            //Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("User with Id 4 not found", exception.Message);
        }

        [Fact]
        public void GetAllAuthors_WithNoExistAuthor_ShouldReturn_()
        {
            //Arrange
            using var context = _database.CreateContext();
            var repository = new AuthorRepository(context);

            foreach (var author in repository.GetAll())
            {
                repository.Remove(author);
            }

            var expected = new List<Author>();

            //Act
            var actual = repository.GetAllAuthors();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void InsertAuthor_WithNoExistAuthor()
        {
            //Arrange
            using var context = _database.CreateContext();
            var repository = new AuthorRepository(context);

            //Act
            Action act = () => repository.Insert(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void DeleteAuthor_WithNoExistAuthor()
        {
            //Arrange
            using var context = _database.CreateContext();
            var repository = new AuthorRepository(context);

            //Act
            Action act = () => repository.Remove(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void UpdateAuthor_WithNoExistAuthor()
        {
            //Arrange
            using var context = _database.CreateContext();
            var repository = new AuthorRepository(context);

            //Act
            Action act = () => repository.Update(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
