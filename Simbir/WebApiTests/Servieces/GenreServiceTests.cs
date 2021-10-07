using AutoMapper;
using Domain.DTO.GenreDtos;
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
    public class GenreServiceTests
    {
        private IMapper _mapper;
        private Mock<IGenreRepository> mock;
        private GenreService service;
        private DatabaseFixture _database;

        public GenreServiceTests(DatabaseFixture fixture)
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

                mock = new Mock<IGenreRepository>();
                service = new GenreService(mock.Object, _mapper);

                mock.Setup(repo => repo.GetGenre(1))
                                    .Returns(_database.genreEntity.First);

                mock.Setup(repo => repo.GetAllGenres())
                                    .Returns(_database.genreEntity);
            }
        }

        [Fact]
        public void GetGenre_WithExistGenre_ShouldReturn_GenreWithoutBooksDto()
        {
            //Arrange 
            var genre = _database.genreEntity.First();
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
            var genre = _database.genreEntity;
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
            var genre = _database.genreEntity;
            var expected = _mapper.ProjectTo<GenreStatisticsDto>(genre);

            //Act
            var actual = service.GetGenreStatistics();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
