﻿using Data.DTO;
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

        public BooksController(IBookService userService)
        {
            _userService = userService;
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
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<BookDto> GetByAuthor([FromBody] HumanDto author)
        {
            return Books.AuthoredBy(author);
        }

        [Route("[action]")]
        [HttpPost]
        public string PostAddBook([FromBody] BookDto book)
        {
            return Books.AddBook(book);
        }

        [Route("[action]")]
        [HttpDelete]
        public string DeleteBook([FromBody] BookDto book)
        {
            return Books.DeleteBook(book);
        }


        /// <summary>
        /// Часть 2.2 п.2 Добавление возможности сделать
        /// запрос с сортировкой по автору, жанру или имени книги
        /// </summary>
        /// <returns></returns>

        [Route("[action]/SortBy")]
        [HttpGet]
        public IEnumerable<BookDto> GetSortedBy(string sortBy)
        {
            return Books.GetSortedBy(sortBy);
        }
    }
}
