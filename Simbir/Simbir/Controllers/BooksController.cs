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
        /// <summary>
        /// Часть 2. п.4 Создание контроллера, отвечающего за книгу
        /// </summary>
        /// <returns></returns>

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAll()
        {
            //Не возвращается список жанров, видимо из за ограничений вложенности JSON
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
            catch
            {
                return BadRequest();
            }
        }

        //[Route("[action]")]
        //[HttpGet]
        //public IActionResult GetByAuthor([FromQuery] int authorId)
        //{
        //    try
        //    {
        //        var model = new List<BookDto>();
        //        _bookService.GetAuthorBooks(authorId).ToList().ForEach(book =>
        //        {
        //            var author = _authorService.GetAuthor(book.AuthorId);
        //            BookDto bookDto = (Book)book;
        //            bookDto.Author = author;
        //            _bookGenreService.GetBookGenre(book.Id).ToList().ForEach(bookGenre =>
        //            {
        //                var genre = _genreService.GetGenre(bookGenre.GenreId);
        //                bookDto.Genres.Add(genre);
        //            });
        //            model.Add(bookDto);
        //        });
        //        return Ok(model);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetByAuthorQuery([FromQuery] string query)
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
            catch
            {
                return BadRequest();
            }

        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult PostAddGenreToBook([FromBody] BookDto bookDto)
        {
            //Каждый раз инкрементирует Id в базе, из за чего появляются дупликаты отличающиеся только Id
            try
            {
                var book = _bookService.GetBook(bookDto.Id);
                bookDto.Genres.ForEach(genreDto =>
                {
                    var genre = _genreService.GetGenre(genreDto.Id);
                    _bookGenreService.AddGenreBook(book, genre);
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Книга не была добавлена! " + ex.Message);
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
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

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
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpDelete]
        public IActionResult DeleteBook([FromBody] BookDto bookDto)
        {
            try
            {
                var genres = _genreService.GetAllGenres();
                var book = _bookService.GetBook(bookDto.Id);
                bookDto.Genres.ForEach(genre =>
                {
                    _bookGenreService.DeleteBookGenre(book, (Genre)genre);
                });
                _bookService.DeleteBook(book);
                return Ok();
            }
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
            }

        }


        ///// <summary>
        ///// Часть 2.2 п.2 Добавление возможности сделать
        ///// запрос с сортировкой по автору, жанру или имени книги
        ///// </summary>
        ///// <returns></returns>

        [Route("[action]/SortBy")]
        [HttpGet]
        public IActionResult GetSortedBy(string sortBy)
        {
            try
            {
                return Ok(_bookService.GetSortedBy(sortBy));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
