using Data.DTO;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IGenreService
    {
        
        public Genre GetGenre(int genreId);
        public IEnumerable<Genre> GetAllGenres();
        public void AddBookToPerson(Genre genre);
        public void DeleteBookFromPerson(Genre genre);
        public void UpdateBookToPerson(Genre genre);
    }
}
