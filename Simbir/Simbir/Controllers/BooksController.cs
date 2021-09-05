using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simbir.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbir.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// Часть 2. п.4 Создание контроллера, отвечающего за книгу
        /// </summary>
        /// <returns></returns>

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<BookDto> GetAll()
        {
            return Books.BooksList;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<BookDto> GetByAuthor([FromBody]HumanDto author)
        {
            return Books.AuthoredBy(author);
        }

        [Route("[action]")]
        [HttpPost]
        public void PostAddBook([FromBody] BookDto book)
        {
            if (Books.FindBook(book) == null)
                Books.BooksList.Add(book);
        }

        [Route("[action]")]
        [HttpDelete]
        public void DeleteBook([FromBody] BookDto book)
        {
            var findedBook = Books.FindBook(book);
            Books.BooksList.Remove(findedBook);
        }


        /// <summary>
        /// Часть 2.2 п.2 Добавление возможности сделать
        /// запрос с сортировкой по автору, жанру или имени книги
        /// </summary>
        /// <returns></returns>

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<BookDto> GetSortedByAuthor()
        {
            return Books.BooksList.OrderBy(book => book.Author.FullName);
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<BookDto> GetSortedByGenre()
        {
            return Books.BooksList.OrderBy(book => book.Genre);
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<BookDto> GetSortedByTitle()
        {
            return Books.BooksList.OrderBy(book => book.Title);
        }
    }
}
