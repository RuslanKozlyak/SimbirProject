using Domain.DTO.AuthorDtos;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Simbir.Controllers
{

    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthorController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public AuthorController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        /// <summary>
        /// Получить список всех авторов.
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _authorService.GetAllAuthors();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить список книг автора
        /// </summary>
        /// <param name="authorId">Id для поиска автора, чьи книги нужно получить</param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAuthorBooks([FromQuery] int authorId)
        {
            try
            {
                var result = _bookService.GetAuthorBooks(authorId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить книги написанные в определенный год
        /// </summary>
        /// <param name="yearOfWriting">Год, по которому будет производиться поиск</param>
        /// <param name="sortByAlphabet">Сортировка полученных данных: значение true в алфовитном порядке,false - в обратном алфовитному порядке</param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetBookByYear([FromQuery] int yearOfWriting, [FromQuery] bool sortByAlphabet)
        {
            try
            {
                var result = _bookService.GetBookByYear(yearOfWriting, sortByAlphabet);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Поиск людей, в имени, фамилии или отчестве которых содержится поисковая фраза
        /// </summary>
        /// <param name="query">Поисковая фраза</param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAuthorByQuery([FromQuery] string query)
        {
            try
            {
                var result = _authorService.GetAuthorByQuery(query);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Добавление нового автора
        /// </summary>
        /// <param name="authorDto">Добавляемый автор</param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorDto authorDto)
        {
            try
            {
                var result = _authorService.AddAuthor(authorDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Удаление автора
        /// </summary>
        /// <param name="authorId">Id удаляемого автора</param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult DeleteAuthor([FromQuery] int authorId)
        {
            try
            {
                _authorService.DeleteAuthor(authorId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
