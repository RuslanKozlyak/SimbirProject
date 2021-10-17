using AutoMapper;
using Domain.DTO.GenreDtos;
using Domain.RepositoryInterfaces;
using FluentAssertions;
using Moq;
using Service;
using Service.Mapping;
using System.Linq;
using Xunit;

namespace WebApiTests.Services
{
    [Collection("DatabaseCollection")]
    public class GenreServiceTests
    {
        private readonly IMapper _mapper;
        private readonly GenreService service;
        private readonly DatabaseFixture _database;

        public GenreServiceTests(DatabaseFixture fixture)
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

            var mock = new Mock<IGenreRepository>();
            service = new GenreService(mock.Object, _mapper);

            mock.Setup(repo => repo.GetGenre(It.IsAny<int>()))
                                .Returns(_database.GenreEntity.First);

            mock.Setup(repo => repo.GetAllGenres())
                                .Returns(_database.GenreEntity);
        }

        [Fact]
        public void GetGenre_WithExistGenre_ShouldReturn_GenreWithoutBooksDto()
        {
            //Arrange 
            var genre = _database.GenreEntity.First();
            var expected = _mapper.Map<GenreWithoutBooksDto>(genre);

            //Act
            var actual = service.GetGenre(1);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllGenres_WithExistGenre_ShouldReturn_GenreWithoutBooksDto()
        {
            //Arrange 
            var genre = _database.GenreEntity;
            var expected = _mapper.ProjectTo<GenreWithoutBooksDto>(genre);

            //Act
            var actual = service.GetAllGenres();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetGenreStatistics_WithExistGenre_ShouldReturn_GenreWithoutBooksDto()
        {
            //Arrange 
            var genre = _database.GenreEntity;
            var expected = _mapper.ProjectTo<GenreStatisticsDto>(genre);

            //Act
            var actual = service.GetGenreStatistics();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
