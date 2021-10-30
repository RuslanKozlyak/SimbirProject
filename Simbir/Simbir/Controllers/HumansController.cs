using Domain.DTO.BookDtos;
using Domain.DTO.HumanDtos;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Simbir.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class HumansController : ControllerBase
    {
        private readonly IHumanService _humanService;
        private readonly IAuthorService _authorService;

        public HumansController(IHumanService humanService, IAuthorService authorService)
        {
            _humanService = humanService;
            _authorService = authorService;
        }

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _humanService.GetAllHumans();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить всех авторов
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAuthors()
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
        /// Получить книги, которые взял польователь
        /// </summary>
        /// <param name="humanId">Id пользователя для поиска</param>
        /// <returns></returns>
        [Route("[action]/{humanId}")]
        [HttpGet]
        public IActionResult GetHumanBooks(int humanId)
        {
            try
            {
                var result = _humanService.GetHumanBooks(humanId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Добавить книгу пользователю
        /// </summary>
        /// <param name="bookDto">Добавляемая книга</param>
        /// <param name="humanId">Id человека, которому добавляется книга</param>
        /// <returns></returns>
        [Route("[action]/{humanId}")]
        [HttpPost]
        public IActionResult AddBookToPerson([FromBody] BookDto bookDto, int humanId)
        {
            try
            {
                var result = _humanService.AddBookToHuman(bookDto, humanId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Удаление книги у пользователя
        /// </summary>
        /// <param name="bookDto">Удаляемая книга</param>
        /// <param name="humanId">Id пользователя, у которого удалется книга</param>
        /// <returns></returns>
        [Route("[action]/{humanId}")]
        [HttpDelete]
        public IActionResult DeleteBookFromPerson([FromBody] BookDto bookDto, int humanId)
        {
            try
            {
                var result = _humanService.DeleteBookFromHuman(bookDto, humanId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Добавление пользователь
        /// </summary>
        /// <param name="humanDto">Добавляемый пользователь</param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult AddHuman([FromBody] HumanDto humanDto)
        {
            try
            {
                var result = _humanService.AddHuman(humanDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="humanDto">Обновляемый пользователь</param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPut]
        public IActionResult UpdateHuman([FromBody] HumanDto humanDto)
        {
            try
            {
                var result = _humanService.UpdateHuman(humanDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="humanId">Удаляемый пользователь</param>
        /// <returns></returns>
        [Route("[action]/{humanId}")]
        [HttpDelete]
        public IActionResult DeleteHuman(int humanId)
        {
            try
            {
                _humanService.DeleteHuman(humanId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Удаление пользователя по ФИО
        /// </summary>
        /// <param name="fullName">ФИО пользователя, которого нужно удалить</param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpDelete]
        public IActionResult DeleteHumanByName([FromBody] HumanWithoutBooksDto fullName)
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
