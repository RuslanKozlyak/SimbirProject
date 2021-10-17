using Domain.DTO.BookDtos;
using Domain.DTO.GenreDtos;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Simbir.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Получить все книги
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _bookService.GetAllBooks();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить книги, в имени фамилии или отчестве автора которых срдержится поисковая фраза
        /// </summary>
        /// <param name="query">Поисковая фраза</param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetByAuthorQuery([FromQuery] string query)
        {
            try
            {
                var result = _bookService.GetByAuthorQuery(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить книги по имени жанра
        /// </summary>
        /// <param name="genreName">Имя жанра, по которому будет производиться поиск</param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetByGenreQuery([FromQuery] string genreName)
        {
            try
            {
                var result = _bookService.GetByGenreQuery(genreName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Добавить книге новый жанр
        /// </summary>
        /// <param name="genreDto">Добавляемый жанр</param>
        /// <param name="bookId">Id книги, к которой добавляется жанр</param>
        /// <returns></returns>
        [Route("[action]/{bookId}")]
        [HttpPost]
        public IActionResult AddGenreToBook([FromBody] GenreWithoutBooksDto genreDto, int bookId)
        {
            try
            {
                var result = _bookService.AddGenreToBook(genreDto, bookId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Удаление жанра у книги
        /// </summary>
        /// <param name="genreDto">Удаляемый жанр</param>
        /// <param name="bookId">Id книги, у которойу удаляется жанр</param>
        /// <returns></returns>
        [Route("[action]/{bookId}")]
        [HttpDelete]
        public IActionResult DeleteBookGenre([FromBody] GenreWithoutBooksDto genreDto, int bookId)
        {
            try
            {
                var result = _bookService.DeleteGenreFromeBook(genreDto, bookId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Добавление книги
        /// </summary>
        /// <param name="bookDto">Добавляемая книга</param>
        /// <returns></returns>
        [Route("[action]/{bookId}")]
        [HttpPost]
        public IActionResult AddBook([FromBody] BookDto bookDto)
        {
            try
            {
                var result = _bookService.AddBook(bookDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Удаление книги
        /// </summary>
        /// <param name="bookId">Id удаляемой книги</param>
        /// <returns></returns>
        [Route("[action]/{bookId}")]
        [HttpDelete]
        public IActionResult DeleteBook([FromQuery] int bookId)
        {
            try
            {
                _bookService.DeleteBook(bookId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Обновление книги
        /// </summary>
        /// <param name="bookDto">Обновленная книга</param>
        /// <returns></returns>
        [Route("[action]/{bookId}")]
        [HttpPost]
        public IActionResult UpdateBook([FromBody] BookDto bookDto)
        {
            try
            {
                var result = _bookService.UpdateBook(bookDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public enum SortBy
        {
            Author,
            Title,
            Genre
        }

        /// <summary>
        /// Получить все книги, отсортированные по одному из трех параметров
        /// </summary>
        /// <param name="sortBy">Параметры сортировки: по названию, по автору, по жанру</param>
        /// <returns></returns>
        [Route("[action]/SortBy")]
        [HttpGet]
        public IActionResult GetSortedBy(SortBy sortBy)
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
