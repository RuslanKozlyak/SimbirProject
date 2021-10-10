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
