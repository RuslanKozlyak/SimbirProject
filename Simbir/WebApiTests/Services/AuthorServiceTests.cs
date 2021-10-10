using AutoMapper;
using Domain.Data;
using Domain.DTO.AuthorDtos;
using Domain.RepositoryInterfaces;
using FluentAssertions;
using Moq;
using Service;
using Service.Mapping;
using System;
using System.Linq;
using Xunit;

namespace WebApiTests.Services
{
    [Collection("DatabaseCollection")]
    public class AuthorServiceTests
    {
        private readonly IMapper _mapper;
        private readonly AuthorService service;
        private readonly DatabaseFixture _database;

        public AuthorServiceTests(DatabaseFixture fixture)
        {
            _database = fixture;
            _database.CreateContext();

            _mapper = new Mapper(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AuthorMap());
                mc.AddProfile(new BookMap());
                mc.AddProfile(new GenreMap());
                mc.AddProfile(new HumanMap());
            }));

            var mock = new Mock<IAuthorRepository>();
            service = new AuthorService(mock.Object, _mapper);

            mock.Setup(repo => repo.GetAuthor(It.IsAny<int>()))
                                .Returns(_database.AuthorEntity.First);

            mock.Setup(repo => repo.GetAllAuthors())
                                .Returns(_database.AuthorEntity.AsQueryable);
        }

        [Fact]
        public void GetAuthor_WithExistAuthor_ShouldReturn_AuthorWithoutBooksDto()
        {
            //Arrange 
            var author = _database.AuthorEntity.First();
            var expected = _mapper.Map<AuthorWithoutBooksDto>(author);

            //Act
            var actual = service.GetAuthor(2);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllAuthors_WithExistBooks_ShouldReturn_ListAuthorWithoutBooksDto()
        {
            //Arrange 
            var author = _database.AuthorEntity;
            var expected = _mapper.ProjectTo<AuthorWithoutBooksDto>(author);

            //Act
            var actual = service.GetAllAuthors();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAuthorByQuery_WithExistBooks_ShouldReturn_ListAuthorWithoutBooksDto()
        {
            //Arrange 
            var author = _database.AuthorEntity.Where(author => author.LastName == "Пушкин");
            var expected = _mapper.ProjectTo<AuthorWithoutBooksDto>(author);

            //Act
            var actual = service.GetAuthorByQuery("Пушкин");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
