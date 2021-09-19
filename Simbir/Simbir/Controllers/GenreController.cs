using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Simbir.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simbir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IHumanService _humanService;
        private readonly IBookService _bookService;
        private readonly IBookGenreService _bookGenreService;
        private readonly IGenreService _genreService;
        private readonly ILibraryCardService _libraryCardService;
        private readonly IAuthorService _authorService;

        public GenreController(IHumanService humanService, IBookGenreService bookGenreService,
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
        /// Часть 2 п 7.4.1 Просмотр всех жанров. (без книг) 
        /// </summary>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var model = new List<GenreDto>();
                _genreService.GetAllGenres().ToList().ForEach(genre =>
                {
                    var genreDto = (GenreDto)genre;
                    model.Add(genreDto);
                });
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.4.2 Добавление нового жанра. (без книги) 
        /// </summary>
        [Route("[action]")]
        [HttpPost]
        public IActionResult PostAddGenre([FromBody] GenreDto genreDto)
        {
            try
            {
                var genre = (Genre)genreDto;
                _genreService.AddGenre(genre);
                return Ok("Жанр добавлен!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Часть 2 п 7.4.3 Вывод статистики Жанр - количество книг
        /// </summary>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetGenreStatistic()
        {
            try
            {
                string genreStatistic = String.Empty;
                _genreService.GetAllGenres().ToList().ForEach(genre =>
                {
                    var count = _bookGenreService.GetBookGenre(genre.Id).Count();
                    genreStatistic += $"{genre.GenreName} - {count} \n";
                });

                return Ok(genreStatistic);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
