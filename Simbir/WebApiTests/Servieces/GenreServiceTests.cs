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
    public class GenreServiceTests
    {
        private static IMapper _mapper;

        public GenreServiceTests()
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
        public void GetGenre_WithExistGenre_ShouldReturn_GenreWithoutBooksDto()
        {
            var mock = new Mock<IRepository<Genre>>();
            var service = new GenreService(mock.Object, _mapper);
            var genre = new Genre
            {
                Id = 1,
                GenreName = "Роман",
                Books = new List<Book>()
            };
            mock.Setup(repo => repo.Get(1)).Returns(genre);
            var expected = new GenreWithoutBooksDto
            {
                GenreName = "Роман"
            };
           
            var actual = service.GetGenre(1);

            Assert.Equal(expected.GenreName, actual.GenreName);
        }

        [Fact]
        public void GetAllGenres_WithExistGenre_ShouldReturn_GenreWithoutBooksDto()
        {
            var mock = new Mock<IRepository<Genre>>();
            var service = new GenreService(mock.Object, _mapper);
            var genre = new Genre
            {
                Id = 1,
                GenreName = "Роман",
                Books = new List<Book>()
            };
            var genres = new List<Genre>();
            genres.Add(genre);
            mock.Setup(repo => repo.GetAll()).Returns(genres);
            var expected = new GenreWithoutBooksDto
            {
                GenreName = "Роман"
            };

            var actualGenress = service.GetAllGenres();
            var actual = new List<GenreWithoutBooksDto>();
            foreach (var a in actualGenress)
                actual.Add(a);

            Assert.Equal(expected.GenreName, actual[0].GenreName);
        }

        [Fact]
        public void GetGenreStatistics_WithExistGenre_ShouldReturn_GenreWithoutBooksDto()
        {
            var mock = new Mock<IRepository<Genre>>();
            var service = new GenreService(mock.Object, _mapper);
            var genre = new Genre
            {
                Id = 1,
                GenreName = "Роман",
                Books = new List<Book>()
            };
            var book = new Book
            {
                Title = "Евгений Онегин",
                YearOfWriting = 1830,
            };
            genre.Books.Add(book);
            var genres = new List<Genre>();
            genres.Add(genre);
            mock.Setup(repo => repo.GetAll(include => include.Books)).Returns(genres);
            var expected = new GenreStatisticsDto
            {
                GenreName = "Роман",
                Count = 1
            };

            var actualGenress = service.GetGenreStatistics();
            var actual = new List<GenreStatisticsDto>();
            foreach (var a in actualGenress)
                actual.Add(a);

            Assert.Equal(expected.GenreName, actual[0].GenreName);
            Assert.Equal(expected.Count, actual[0].Count);
        }
    }
}
