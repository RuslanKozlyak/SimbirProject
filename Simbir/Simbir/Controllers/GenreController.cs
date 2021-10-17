using Domain.DTO.GenreDtos;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Simbir.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _genreService.GetAllGenres();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddGenre([FromBody] GenreWithoutBooksDto genreDto)
        {
            try
            {
                var result = _genreService.AddGenre(genreDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetGenreStatistic()
        {
            try
            {
                var result = _genreService.GetGenreStatistics();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
