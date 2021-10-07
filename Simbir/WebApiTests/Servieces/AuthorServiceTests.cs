
using AutoMapper;
using Domain.DTO.AuthorDtos;
using Domain.RepositoryInterfaces;
using FluentAssertions;
using Moq;
using Service;
using Service.Mapping;
using System.Linq;
using Xunit;

namespace WebApiTests.Servieces
{
    [Collection("DatabaseCollection")]
    public class AuthorServiceTests
    {
        private IMapper _mapper;
        private Mock<IAuthorRepository> mock;
        private AuthorService service;
        private DatabaseFixture _database;

        public AuthorServiceTests(DatabaseFixture fixture)
        {
            if (_mapper == null)
            {
                _database = fixture;
                var context = _database.CreateContext();

                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AuthorMap());
                    mc.AddProfile(new BookMap());
                    mc.AddProfile(new GenreMap());
                    mc.AddProfile(new HumanMap());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;

                mock = new Mock<IAuthorRepository>();
                service = new AuthorService(mock.Object, _mapper);

                mock.Setup(repo => repo.GetAuthor(1))
                                    .Returns(_database.authorEntity.First);

                mock.Setup(repo => repo.GetAllAuthors())
                                    .Returns(_database.authorEntity);
            }
        }

        [Fact]
        public void GetAuthor_WithExistAuthor_ShouldReturn_AuthorWithoutBooksDto()
        {
            //Arrange 
            var author = _database.authorEntity.First();
            var expected = _mapper.Map<AuthorWithoutBooksDto>(author);

            //Act
            var actual = service.GetAuthor(1);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllAuthors_WithExistbooks_ShouldReturn_ListAuthorWithoutBooksDto()
        {
            //Arrange 
            var author = _database.authorEntity;
            var expected = _mapper.ProjectTo<AuthorWithoutBooksDto>(author);

            //Act
            var actual = service.GetAllAuthors();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAuthorByQuery_WithExistbooks_ShouldReturn_ListAuthorWithoutBooksDto()
        {
            //Arrange 
            var author = _database.authorEntity.Where(author => author.LastName == "Пушкин");
            var expected = _mapper.ProjectTo<AuthorWithoutBooksDto>(author);

            //Act
            var actual = service.GetAuthorByQuery("Пушкин");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
