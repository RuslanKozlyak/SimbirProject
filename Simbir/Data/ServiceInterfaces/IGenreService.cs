using Domain.DTO.GenreDtos;
using System.Collections.Generic;

namespace Domain.ServiceInterfaces
{
    /// <summary>
    /// Часть 2. п.7.4 Переработать контроллера, отвечающего за жанры
    /// </summary>
    public interface IGenreService
    {
        public GenreWithoutBooksDto GetGenre(int genreId);

        /// <summary>
        /// Часть 2 п 7.4.1 Просмотр всех жанров. (без книг) 
        /// </summary>
        public IEnumerable<GenreWithoutBooksDto> GetAllGenres();

        /// <summary>
        /// Часть 2 п 7.4.3 Вывод статистики Жанр - количество книг
        /// </summary>
        public IEnumerable<GenreStatisticsDto> GetGenreStatistics();

        /// <summary>
        /// Часть 2 п 7.4.2 Добавление нового жанра. (без книги) 
        /// </summary>
        public GenreWithoutBooksDto AddGenre(GenreWithoutBooksDto genreDto);

        public void DeleteGenre(int genreId);

        public GenreWithoutBooksDto UpdateGenre(GenreDto genreDto);
    }
}
