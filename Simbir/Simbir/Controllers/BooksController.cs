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
        [Route("[action]")]
        [HttpGet]
        public IEnumerable<BookDto> GetAll()
        {
            return Books.ListOfBooks;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<BookDto> GetByAuthor(string author)
        {
            return Books.AuthoredBy(author);
        }

        [Route("[action]")]
        [HttpPost]
        public void PostAddBook([FromBody] BookDto book)
        {
            if (Books.FindBook(book) == null)
                Books.ListOfBooks.Add(book);
        }

        [Route("[action]")]
        [HttpDelete]
        public void DeleteBook([FromBody] BookDto book)
        {
            var findedBook = Books.FindBook(book);
            Books.ListOfBooks.Remove(findedBook);
        }
    }
}
