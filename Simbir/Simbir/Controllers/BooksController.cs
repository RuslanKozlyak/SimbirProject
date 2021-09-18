using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Simbir.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simbir.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IHumanService _humanService;
        private readonly IBookService _bookService;
        private readonly IBookGenreService _bookGenreService;
        private readonly IGenreService _genreService;
        private readonly ILibraryCardService _libraryCardService;
        private readonly IAuthorService _authorService;

        public BooksController(IHumanService humanService, IBookGenreService bookGenreService,
            IGenreService genreService, ILibraryCardService libraryCardService, IBookService bookService, IAuthorService authorService)
        {
            _humanService = humanService;
            _bookService = bookService;
            _bookGenreService = bookGenreService;
            _genreService = genreService;
            _libraryCardService = libraryCardService;
            _authorService = authorService;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var model = new List<BookDto>();
                _bookService.GetAllBooks().ToList().ForEach(book =>
                {
                    var author = _authorService.GetAuthor(book.AuthorId);
                    BookDto bookDto = (Book)book;
                    bookDto.Author = author;
                    _bookGenreService.GetBookGenre(book.Id).ToList().ForEach(bookGenre =>
                    {
                        var genre = _genreService.GetGenre(bookGenre.GenreId);
                        bookDto.Genres.Add(genre);
                    });
                    model.Add(bookDto);
                });
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.2.4 Можно получить список всех книг с фильтром по автору 
        /// (По любой комбинации трёх полей сущности автор. Имеется 
        /// ввиду условие equals + and )
        /// </summary>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetByAuthorQuery([FromQuery] string query)
        {
            try
            {
                var model = new List<BookDto>();
                _authorService.GetAuthorByQuery(query).ToList().ForEach(author =>
                {
                    _bookService.GetAuthorBooks(author.Id).ToList().ForEach(book =>
                    {
                        var author = _authorService.GetAuthor(book.AuthorId);
                        BookDto bookDto = (Book)book;
                        bookDto.Author = author;
                        _bookGenreService.GetBookGenre(book.Id).ToList().ForEach(bookGenre =>
                        {
                            var genre = _genreService.GetGenre(bookGenre.GenreId);
                            bookDto.Genres.Add(genre);
                        });
                        model.Add(bookDto);
                    });
                });
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.2.5 Можно получить список книг по жанру.
        /// Книга + жанр + автор
        /// </summary>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetByGenreQuery([FromQuery] string genreName)
        {
            try
            {
                var model = new List<BookDto>();
                var genre = _genreService.GetAllGenres().FirstOrDefault(genre => genre.GenreName.ToUpper() == genreName.ToUpper());
                _bookGenreService.GetAllBookGenres().Where(bookGenre => bookGenre.GenreId == genre.Id).ToList().ForEach(bg =>
                {
                    var book = _bookService.GetBook(bg.BookId);
                    var author = _authorService.GetAuthor(book.AuthorId);
                    BookDto bookDto = (Book)book;
                    bookDto.Author = author;
                    _bookGenreService.GetBookGenre(book.Id).ToList().ForEach(bookGenre =>
                    {
                        var genre = _genreService.GetGenre(bookGenre.GenreId);
                        bookDto.Genres.Add(genre);
                    });
                    model.Add(bookDto);
                });
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.2.3 Книге можно присвоить новый жанр, или удалить один
        /// из имеющихся (PUT с телом.На вход сущность Book или её Dto)
        /// При добавлении или удалении вы должны просто либо добавлять
        /// запись, либо удалять из списка жанров. 
        /// Каскадно удалять все жанры и книги с таким жанром нельзя!
        /// Книга + жанр + автор
        /// </summary>
        [Route("[action]")]
        [HttpPost]
        public IActionResult PostAddGenreToBook([FromBody] BookDto bookDto)
        {
            try
            {
                var book = _bookService.GetBook(bookDto.Id);
                bookDto.Genres.ForEach(genreDto =>
                {
                    var genre = _genreService.GetGenre(genreDto.Id);
                    _bookGenreService.AddGenreBook(book, genre);
                });
                return Ok("К книге добавлен жанр!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpDelete]
        public IActionResult DeleteBookGenre([FromBody] BookDto bookDto)
        {
            try
            {
                var book = _bookService.GetBook(bookDto.Id);
                bookDto.Genres.ForEach(genreDto =>
                {
                    var genre = _genreService.GetGenre(genreDto.Id);
                    _bookGenreService.DeleteBookGenre(book, genre);
                });
                return Ok("У книги удален жанр!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.2.1 Книга может быть добавлена (POST)
        /// (вместе с автором и жанром) книга + автор + жанр
        /// </summary>
        [Route("[action]")]
        [HttpPost]
        public IActionResult PostAddBook([FromBody] BookDto bookDto)
        {
            try
            {
                if (_authorService.GetAuthor(bookDto.AuthorId) == null)
                    _authorService.AddAuthor((Author)bookDto.Author);
                var genres = _genreService.GetAllGenres();
                var book = (Book)bookDto;
                _bookService.AddBook(book);
                bookDto.Genres.ForEach(genre =>
                {
                    if (genres.FirstOrDefault(g => g.GenreName == genre.GenreName) == null)
                        _genreService.AddGenre((Genre)genre);
                    _bookGenreService.AddGenreBook(book, (Genre)genre);
                });
                return Ok("Книга добавлена!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.2.2 Книга может быть удалена из списка библиотеки 
        /// (но только если она не у пользователя) по ID
        /// (ок, или ошибка, что книга у пользователя)
        /// </summary>
        [Route("[action]")]
        [HttpDelete]
        public IActionResult DeleteBook([FromBody] BookDto bookDto)
        {
            try
            {
                var cards = _libraryCardService.GetAllCards().Where(card => card.BookId == bookDto.Id);
                if (cards == null)
                {
                    var genres = _genreService.GetAllGenres();
                    var book = _bookService.GetBook(bookDto.Id);
                    bookDto.Genres.ForEach(genre =>
                    {
                        _bookGenreService.DeleteBookGenre(book, (Genre)genre);
                    });
                    _bookService.DeleteBook(book);
                    return Ok("Книга удалена!");
                }
                else
                {
                    return BadRequest("Книга у пользователя!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult UpdateBook([FromBody] BookDto bookDto)
        {
            try
            {
                Book book = (Book)bookDto;
                return Ok(_bookService.UpdateBook(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]/SortBy")]
        [HttpGet]
        public IActionResult GetSortedBy(string sortBy)
        {
            try
            {
                return Ok(_bookService.GetSortedBy(sortBy));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
