using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Simbir.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simbir.Controllers
{
    /// <summary>
    /// Часть 2. п.3 Создание контроллера, отвечающего за человека
    /// </summary>
    /// <returns></returns>

    [ApiController]
    [Route("[controller]")]
    public class HumansController : ControllerBase
    {
        private readonly IHumanService _humanService;
        private readonly IBookService _bookService;
        private readonly IBookGenreService _bookGenreService;
        private readonly IGenreService _genreService;
        private readonly ILibraryCardService _libraryCardService;
        private readonly IAuthorService _authorService;

        public HumansController(IHumanService humanService, IBookGenreService bookGenreService,
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
                var model = new List<HumanDto>();
                _humanService.GetAllHumans().ToList().ForEach(human =>
                {
                    HumanDto humanDto = (HumanDto)human;
                    model.Add(humanDto);
                });
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAuthors()
        {
            try
            {
                var model = new List<AuthorDto>();
                _authorService.GetAllAuthors().ToList().ForEach(author =>
                {
                    AuthorDto authorDto = (AuthorDto)author;
                    model.Add(authorDto);
                });
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetQuery([FromQuery] string query)
        {
            try
            {
                var model = new List<HumanDto>();
                _humanService.GetHumanByQuery(query).ToList().ForEach(human =>
                {
                    HumanDto humanDto = (HumanDto)human;
                    model.Add(humanDto);
                });
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.1.5 Получить список всех взятых пользователем книг (GET)
        /// в качестве параметра поиска - ID пользователя. Полное дерево:
        /// Книги - автор - жанр
        /// </summary>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetHumanBooks([FromQuery] int humanId)
        {
            try
            {
                var model = new List<BookDto>();
                _libraryCardService.GetHumanBooks(humanId).ToList().ForEach(humanBook =>
                {
                        var book= _bookService.GetBook(humanBook.BookId);
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
        /// Часть 2 п 7.1.6 Пользователь может взять книгу
        /// (добавить в список книг пользователя книгу)  Пользователь + книги
        /// </summary>
        [Route("[action]")]
        [HttpPost]
        public IActionResult PostPickupBook([FromBody] HumanDto humanDto)
        {
            try
            {
                var model = new List<LibraryCardDto>();
                Human human = (Human)humanDto;
                humanDto.Books.ForEach(bookDto =>
                {
                    Book book = (Book)bookDto;
                    var addedCard = _libraryCardService.AddBookToPerson(human, book);
                    LibraryCardDto cardDto = (LibraryCardDto)addedCard;
                    model.Add(cardDto);
                });
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.1.7 Пользователь может вернуть книгу
        /// (добавить в список книг пользователя книгу)  Пользователь + книги
        /// </summary>
        [Route("[action]")]
        [HttpDelete]
        public IActionResult DeleteBookFromPerson([FromBody] HumanDto humanDto)
        {
            try
            {
                Human human = (Human)humanDto;
                humanDto.Books.ForEach(bookDto =>
                {
                    Book book = (Book)bookDto;
                    _libraryCardService.DeleteBookFromPerson(human, book);
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.1.1 Пользователь может быть добавлен. (POST) (вернуть пользователя)
        /// </summary>

        [Route("[action]")]
        [HttpPost]
        public IActionResult PostAddHuman([FromBody] HumanDto humanDto)
        {
            try
            {
                Human human = (Human)humanDto;
                return Ok(_humanService.AddHuman(human));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.1.2 Информация о пользователе может быть изменена (PUT) (вернуть пользователя)
        /// </summary>

        [Route("[action]")]
        [HttpPut]
        public IActionResult UpdateHuman([FromBody] HumanDto humanDto)
        {
            try
            {
                Human human = (Human)humanDto;
                return Ok(_humanService.UpdateHuman(human));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.1.3 Пользователь может быть удалён по ID (DELETE) (ок или ошибку, если такого id нет)
        /// </summary>

        [Route("[action]")]
        [HttpDelete]
        public IActionResult DeleteHuman([FromBody] HumanDto humanDto)
        {
            try
            {
                if (_humanService.GetHuman(humanDto.Id) != null)
                {
                    Human human = (Human)humanDto;
                    return Ok(_humanService.DeleteHuman(human));
                }
                else
                {
                    return BadRequest("Такого Id нет!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.1.4 Пользователь или пользователи могут быть удалены по ФИО (не заботясь о том что могут быть полные тёзки. Без пощады.) (DELETE) Ok - или ошибку, если что-то пошло не так. 
        /// </summary>


        [Route("[action]")]
        [HttpDelete]
        public IActionResult DeleteHumanByName([FromQuery] string fullName)
        {
            try
            {
                _humanService.DeleteHumanByName(fullName);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
