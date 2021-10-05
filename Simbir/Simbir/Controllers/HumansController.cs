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

        [Route("[action]/{humanId}")]
        [HttpPost]
        public IActionResult AddBookToPerson([FromBody] HumanWithBooksDto humanDto, int humanId)
        {
            try
            {
                var result = _humanService.AddBookToHuman(humanDto, humanId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]/{humanId}")]
        [HttpDelete]
        public IActionResult DeleteBookFromPerson([FromBody] HumanWithBooksDto humanDto, int humanId)
        {
            try
            {
                var result = _humanService.DeleteBookFromHuman(humanDto, humanId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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
