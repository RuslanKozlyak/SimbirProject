using Data.DTO;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IGenreService
    {

        public Genre GetGenre(int genreId);
        public IEnumerable<Genre> GetAllGenres();
        public void AddGenre(Genre genre);
        public void DeleteGenre(Genre genre);
        public void UpdateGenre(Genre genre);
    }
}
