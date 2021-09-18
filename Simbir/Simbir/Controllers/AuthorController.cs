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
    public class AuthorController : ControllerBase
    {
        private readonly IHumanService _humanService;
        private readonly IBookService _bookService;
        private readonly IBookGenreService _bookGenreService;
        private readonly IGenreService _genreService;
        private readonly ILibraryCardService _libraryCardService;
        private readonly IAuthorService _authorService;

        public AuthorController(IHumanService humanService, IBookGenreService bookGenreService,
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
        /// Часть 2 п 7.3.1 Можно получить список всех авторов.
        /// (без книг, как и везде, где не указано обратное)
        /// </summary>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var model = new List<AuthorDto>();
                _authorService.GetAllAuthors().ToList().ForEach(author =>
                {
                    AuthorDto authorDto = author;
                    _bookService.GetAuthorBooks(author.Id).ToList().ForEach(book =>
                    {
                        _bookGenreService.GetBookGenre(book.Id).ToList().ForEach(bookGenre =>
                        {
                            BookDto bookDto = (Book)book;
                            var genre = _genreService.GetGenre(bookGenre.GenreId);
                            bookDto.Genres.Add(genre);
                            authorDto.Books.Add(bookDto);
                        });
                    });
                    model.Add(authorDto);
                });
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.3.2 Можно получить список книг автора (книг может и не быть).
        /// автор + книги + жанры
        /// </summary>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAuthorBooks([FromQuery] int authorId)
        {
            try
            {
                var model = new List<BookDto>();
                _bookService.GetAuthorBooks(authorId).ToList().ForEach(book =>
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
        /// Создать новый контроллер, метод  которого будет выводить список всех авторов,
        /// у которых есть хотя бы одна книга, написанная в определенный год(этот год прокидывать
        /// в query параметрах контроллера). Отсортировать список авторов по алфавиту.
        /// Предусмотреть возможность сортировки по возрастанию и по убыванию
        /// (этот параметр также передавать через параметры контроллера)
        /// </summary>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetBookByYear([FromQuery] DateTime yearOfWriting, [FromQuery] bool alphabetSort)
        {
            try
            {
                var model = new List<AuthorDto>();
                _bookService.GetAllBooks().Where(book => book.YearOfWriting == yearOfWriting).ToList().ForEach(findedBook =>
                {
                    var author = _authorService.GetAuthor(findedBook.AuthorId);
                    model.Add(author);
                });
                model.OrderBy(author => author.FirstName);
                if (alphabetSort)
                    return Ok(model);
                else
                {
                    model.Reverse();
                    return Ok(model);
                }
                    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetBookByQuery([FromQuery] string query)
        {
            try
            {
                var model = new List<AuthorDto>();
                _bookService.GetAllBooks().Where(book => book.Title.ToUpper().Contains(query.ToUpper())).ToList().ForEach(findedBook =>
                {
                    var author = _authorService.GetAuthor(findedBook.AuthorId);
                    model.Add(author);
                });
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.3.3 Добавить автора (с книгами или без) ответ - автор + книги
        /// </summary>
        [Route("[action]")]
        [HttpPost]
        public IActionResult PostAddAuthor([FromBody] AuthorDto authorDto)
        {
            try
            {
                var author = (Author)authorDto;
                _authorService.AddAuthor(author);
                if (authorDto.Books != null)
                    authorDto.Books.ForEach(bookDto =>
                         {
                             var genres = _genreService.GetAllGenres();
                             var book = (Book)bookDto;
                             _bookService.AddBook(book);
                             bookDto.Genres.ForEach(genre =>
                             {
                                 if (genres.FirstOrDefault(g => g.GenreName == genre.GenreName) == null)
                                     _genreService.AddGenre((Genre)genre);
                                 _bookGenreService.AddGenreBook(book, (Genre)genre);
                             });
                         });
                return Ok("Автор добавлен!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.3.4 Удалить автора (если только нет книг, 
        /// иначе кидать ошибку с пояснением, что нельзя удалить автора пока есть его книги) - Ок или Ошибка.
        /// </summary>
        [Route("[action]")]
        [HttpPost]
        public IActionResult PostDeleteAuthor([FromBody] AuthorDto authorDto)
        {
            try
            {
                var author = (Author)authorDto;
                var books = _bookService.GetAuthorBooks(authorDto.Id);
                if (books == null)
                {
                    _authorService.DeleteAuthor(author);
                    return Ok("Автор удален!");
                }
                else
                {
                    return BadRequest("Вы не можете удалить автора не удалив его книги.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
