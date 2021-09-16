using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Simbir.DTO;
using System.Collections.Generic;

namespace Simbir.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _userService;

        private readonly IHumanService _humanService;
        private readonly IBookService _bookService;
        private readonly IBookGenreService _bookGenreService;
        private readonly IGenreService _genreService;
        private readonly ILibraryCardService _libraryCardService;
        private readonly IAuthorService _authorService;

        public BooksController(IHumanService humanService, IBookGenreService bookGenreService,
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
        /// Часть 2. п.4 Создание контроллера, отвечающего за книгу
        /// </summary>
        /// <returns></returns>

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return _userService.GetAllBooks();

            try
            {
                var model = new List<BookDto>();
                _bookService.GetAllBooks().ToList().ForEach(human =>
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

        //[Route("[action]")]
        //[HttpGet]
        //public IEnumerable<BookDto> GetByAuthor([FromBody] HumanDto author)
        //{
        //    return Books.AuthoredBy(author);
        //}

        //[Route("[action]")]
        //[HttpPost]
        //public string PostAddBook([FromBody] BookDto book)
        //{
        //    return Books.AddBook(book);
        //}

        //[Route("[action]")]
        //[HttpDelete]
        //public string DeleteBook([FromBody] BookDto book)
        //{
        //    return Books.DeleteBook(book);
        //}


        ///// <summary>
        ///// Часть 2.2 п.2 Добавление возможности сделать
        ///// запрос с сортировкой по автору, жанру или имени книги
        ///// </summary>
        ///// <returns></returns>

        //[Route("[action]/SortBy")]
        //[HttpGet]
        //public IEnumerable<BookDto> GetSortedBy(string sortBy)
        //{
        //    return Books.GetSortedBy(sortBy);
        //}
    }
}
