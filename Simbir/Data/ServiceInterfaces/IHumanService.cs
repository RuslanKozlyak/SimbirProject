using Domain.DTO.BookDtos;
using Domain.DTO.HumanDtos;
using System.Collections.Generic;

namespace Domain.ServiceInterfaces
{
    /// <summary>
    /// Часть 2. п.7.1 Переработать контроллера, отвечающего за человека
    /// </summary>
    public interface IHumanService
    {
        public IEnumerable<HumanWithoutBooksDto> GetAllHumans();

        public HumanWithoutBooksDto GetHuman(int humanId);

        public IEnumerable<HumanWithoutBooksDto> GetHumanByQuery(string query);

        /// <summary>
        /// Часть 2 п 7.1.5 Получить список всех взятых пользователем книг (GET)
        /// в качестве параметра поиска - ID пользователя. Полное дерево:
        /// Книги - автор - жанр
        /// </summary>
        public IEnumerable<BookWithAuthorAndGenreDto> GetHumanBooks(int humanId);

        /// <summary>
        /// Часть 2 п 7.1.6 Пользователь может взять книгу
        /// (добавить в список книг пользователя книгу)  Пользователь + книги
        /// </summary>
        public HumanWithBooksDto AddBookToHuman(HumanWithBooksDto humanDto, int humanId);

        /// <summary>
        /// Часть 2 п 7.1.7 Пользователь может вернуть книгу
        /// (добавить в список книг пользователя книгу)  Пользователь + книги
        /// </summary>
        public HumanWithBooksDto DeleteBookFromHuman(HumanWithBooksDto humanDto, int humanId);

        /// <summary>
        /// Часть 2 п 7.1.1 Пользователь может быть добавлен. (POST) (вернуть пользователя)
        /// </summary>
        public HumanWithoutBooksDto AddHuman(HumanDto humanDto);

        /// <summary>
        /// Часть 2 п 7.1.3 Пользователь может быть удалён по ID (DELETE) (ок или ошибку, если такого id нет)
        /// </summary>
        public void DeleteHuman(int humanId);

        /// <summary>
        /// Часть 2 п 7.1.2 Информация о пользователе может быть изменена (PUT) (вернуть пользователя)
        /// </summary>
        public HumanWithoutBooksDto UpdateHuman(HumanDto humanDto);

        /// <summary>
        /// Часть 2 п 7.1.4 Пользователь или пользователи могут быть удалены по ФИО (не заботясь о том что могут быть полные тёзки. Без пощады.) 
        /// (DELETE) Ok - или ошибку, если что-то пошло не так. 
        /// </summary>
        public void DeleteHumanByName(HumanWithoutBooksDto humanDto);
    }
}
