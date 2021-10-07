
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

namespace WebApiTests.Servieces
{
    [Collection("DatabaseCollection")]
    public class BookServiceTests
    {
        private IMapper _mapper;
        private Mock<IBookRepository> mock;
        private BookService service;
        private DatabaseFixture _database;

        public BookServiceTests(DatabaseFixture fixture)
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

                mock = new Mock<IBookRepository>();
                service = new BookService(mock.Object, _mapper);

                mock.Setup(repo => repo.GetBook(1))
                                    .Returns(_database.bookEntity.First);

                mock.Setup(repo => repo.GetAllBooks())
                                    .Returns(_database.bookEntity);
            }
        }

        [Fact]
        public void GetBook_WithExistBook_ShouldReturn_BookWithAuthorAndGenreDto()
        {
            //Arrange 
            var book = _database.bookEntity.First();
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
            var book = _database.bookEntity;
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
            var book = _database.authorEntity.First().Books;
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
            var book = _database.authorEntity.Where(author => author.Id == 1).First().Books;
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
            var book = _database.authorEntity.Where(author => author.Id == 1).First().Books;
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
            var book = _database.bookEntity.Where(book => book.YearOfWriting == 1830);
            var expected = _mapper.ProjectTo<BookWithAuthorAndGenreDto>(book.AsQueryable());

            //Act
            var actual = service.GetBookByYear(1830, true);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
