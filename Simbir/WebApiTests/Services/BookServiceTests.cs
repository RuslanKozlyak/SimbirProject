
using AutoMapper;
using Domain.Data;
using Domain.DTO.BookDtos;
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
    public class BookServiceTests
    {
        private readonly IMapper _mapper;
        private readonly BookService service;
        private readonly DatabaseFixture _database;

        public BookServiceTests(DatabaseFixture fixture)
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

                var mock = new Mock<IBookRepository>();
                service = new BookService(mock.Object, _mapper);

                mock.Setup(repo => repo.GetBook(It.IsAny<int>()))
                                    .Returns(_database.BookEntity.First);

                mock.Setup(repo => repo.GetAllBooks())
                                    .Returns(_database.BookEntity);
        }

        [Fact]
        public void GetBook_WithExistBook_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            //Arrange 
            var book = _database.BookEntity.First();
            var expected = _mapper.Map<BookWithAuthorAndGenreDto>(book);

            //Act
            var actual = service.GetBook(1);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllBooks_WithExistbooks_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            //Arrange 
            var book = _database.BookEntity;
            var expected = _mapper.ProjectTo<BookWithAuthorAndGenreDto>(book);

            //Act
            var actual = service.GetAllBooks();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAuthorBooks_WithExistbooks_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            //Arrange 
            var book = _database.AuthorEntity.First().Books;
            var expected = _mapper.ProjectTo<BookWithAuthorAndGenreDto>(book.AsQueryable());

            //Act
            var actual = service.GetAuthorBooks(1);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetByAuthorQuery_WithExistbooks_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            //Arrange 
            var book = _database.AuthorEntity.First().Books;
            var expected = _mapper.ProjectTo<BookWithAuthorAndGenreDto>(book.AsQueryable<Book>());

            //Act
            var actual = service.GetByAuthorQuery("Пушкин");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetByGenreQuery_WithExistbooks_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            //Arrange 
            var book = _database.AuthorEntity.First().Books;
            var expected = _mapper.ProjectTo<BookWithAuthorAndGenreDto>(book.AsQueryable());

            //Act
            var actual = service.GetByGenreQuery("Р");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetBookByYear_WithExistbooks_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            //Arrange 
            var book = _database.BookEntity.Where(book => book.YearOfWriting == 1830);
            var expected = _mapper.ProjectTo<BookWithAuthorAndGenreDto>(book.AsQueryable());

            //Act
            var actual = service.GetBookByYear(1830, true);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
