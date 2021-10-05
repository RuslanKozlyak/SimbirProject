using Domain.DTO.BookDtos;
using Domain.DTO.GenreDtos;
using System;
using System.Collections.Generic;

namespace Domain.ServiceInterfaces
{
    /// <summary>
    /// Часть 2. п.7.2 Переработать контроллера, отвечающего за книгу
    /// </summary>
    public interface IBookService
    {
        public IEnumerable<BookWithAuthorAndGenreDto> GetAllBooks();

        public BookWithAuthorAndGenreDto GetBook(int bookId);

        public IEnumerable<BookWithAuthorAndGenreDto> GetAuthorBooks(int authorId);

        /// <summary>
        /// Часть 2 п 7.2.4 Можно получить список всех книг с фильтром по автору 
        /// (По любой комбинации трёх полей сущности автор. Имеется 
        /// ввиду условие equals + and )
        /// </summary>
        public IEnumerable<BookWithAuthorAndGenreDto> GetByAuthorQuery(string query);

        /// <summary>
        /// Часть 2 п 7.2.5 Можно получить список книг по жанру.
        /// Книга + жанр + автор
        /// </summary>
        public IEnumerable<BookWithAuthorAndGenreDto> GetByGenreQuery(string genreName);

        /// <summary>
        /// Создать новый контроллер, метод  которого будет выводить список всех авторов,
        /// у которых есть хотя бы одна книга, написанная в определенный год(этот год прокидывать
        /// в query параметрах контроллера). Отсортировать список авторов по алфавиту.
        /// Предусмотреть возможность сортировки по возрастанию и по убыванию
        /// (этот параметр также передавать через параметры контроллера)
        /// </summary>
        public IEnumerable<BookWithAuthorAndGenreDto> GetBookByYear(int yearOfWriting, bool alphabetSort);

        public IEnumerable<BookWithAuthorAndGenreDto> GetSortedBy(Enum sortBy);

        /// <summary>
        /// Часть 2 п 7.2.3 Книге можно присвоить новый жанр, или удалить один
        /// из имеющихся (PUT с телом.На вход сущность Book или её Dto)
        /// При добавлении или удалении вы должны просто либо добавлять
        /// запись, либо удалять из списка жанров. 
        /// Каскадно удалять все жанры и книги с таким жанром нельзя!
        /// Книга + жанр + автор
        /// </summary>
        public BookWithAuthorAndGenreDto AddGenreToBook(GenreWithoutBooksDto genreDto, int bookId);

        public BookWithAuthorAndGenreDto DeleteGenreFromeBook(GenreWithoutBooksDto genreDto, int bookId);

        /// <summary>
        /// Часть 2 п 7.2.1 Книга может быть добавлена (POST)
        /// (вместе с автором и жанром) книга + автор + жанр
        /// </summary>
        public BookWithAuthorAndGenreDto AddBook(BookDto bookDto);

        /// <summary>
        /// Часть 2 п 7.2.2 Книга может быть удалена из списка библиотеки 
        /// (но только если она не у пользователя) по ID
        /// (ок, или ошибка, что книга у пользователя)
        /// </summary>
        public void DeleteBook(int bookId);

        public BookWithAuthorAndGenreDto UpdateBook(BookDto bookDto);
    }
}
