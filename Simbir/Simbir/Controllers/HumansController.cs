using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Simbir.DTO;
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
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
            }
           
        }

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
            catch
            {
                return BadRequest();
            }
        }

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
            catch
            {
                return BadRequest();
            }
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult PostAddHuman([FromBody] HumanDto humanDto)
        {
            try
            {
                Human human = (Human)humanDto;
                return Ok(_humanService.AddHuman(human));
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [Route("[action]")]
        [HttpDelete]
        public IActionResult DeleteHuman([FromBody] HumanDto humanDto)
        {
            try
            {
                Human human = (Human)humanDto;
                return Ok(_humanService.DeleteHuman(human));
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult UpdateHuman([FromBody] HumanDto humanDto)
        {
            try
            {
                Human human = (Human)humanDto;
                return Ok(_humanService.UpdateHuman(human));
            }
            catch
            {
               return BadRequest();
            }
            
        }

        [Route("[action]")]
        [HttpDelete]
        public IActionResult DeleteHumanByName([FromQuery] string fullName)
        {
            try
            {
                _humanService.DeleteHumanByName(fullName);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}
