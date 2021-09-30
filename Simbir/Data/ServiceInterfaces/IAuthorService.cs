using Domain.DTO.AuthorDtos;
using System.Collections.Generic;

namespace Domain.ServiceInterfaces
{
    public interface IAuthorService
    {
        public AuthorWithoutBooksDto GetAuthor(int authorId);
        /// <summary>
        /// Часть 2 п 7.3.1 Можно получить список всех авторов.
        /// (без книг, как и везде, где не указано обратное)
        /// </summary>
        public IEnumerable<AuthorWithoutBooksDto> GetAllAuthors();
        /// <summary>
        /// Часть 2 п 7.3.2 Можно получить список книг автора (книг может и не быть).
        /// автор + книги + жанры
        /// </summary>
        public IEnumerable<AuthorWithoutBooksDto> GetAuthorByQuery(string query);
        /// <summary>
        /// Часть 2 п 7.3.3 Добавить автора (с книгами или без) ответ - автор + книги
        /// </summary>
        public AuthorWithBooksDto AddAuthor(AuthorDto authorDto);
        /// <summary>
        /// Часть 2 п 7.3.4 Удалить автора (если только нет книг, 
        /// иначе кидать ошибку с пояснением, что нельзя удалить автора пока есть его книги) - Ок или Ошибка.
        /// </summary>
        public void DeleteAuthor(int authorId);
        public AuthorWithBooksDto UpdateAuthor(AuthorDto authorDto);
    }
}
