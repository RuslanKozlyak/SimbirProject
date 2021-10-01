using Domain.DTO.BookDtos;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Simbir.Controllers
{
    /// <summary>
    /// Часть 2. п.7.2 Переработать контроллера, отвечающего за книгу
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

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

        [Route("[action]/{bookId}")]
        [HttpPost]
        public IActionResult AddGenreToBook([FromBody] BookWithGenreDto bookDto, int bookId)
        {
            try
            {
                var result = _bookService.AddGenreToBook(bookDto, bookId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]/{bookId}")]
        [HttpDelete]
        public IActionResult DeleteBookGenre([FromBody] BookWithGenreDto bookDto, int bookId)
        {
            try
            {
                var result = _bookService.DeleteGenreFromeBook(bookDto, bookId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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

        [Route("[action]/{bookId}")]
        [HttpPost]
        public IActionResult UpdateBook([FromBody] BookDto bookDto, int bookId)
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
