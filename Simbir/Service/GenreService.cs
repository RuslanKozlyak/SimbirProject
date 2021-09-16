using Data.DTO;
using Repository;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GenreService:IGenreService
    {
        private IRepository<Genre> _genreRepository;
        public GenreService(IRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public Genre GetGenre(int genreId)
        {
            return _genreRepository.Get(genreId);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreRepository.GetAll();
        }

        public void AddBookToPerson(Genre genre)
        {
            _genreRepository.Insert(genre);
        }

        public void DeleteBookFromPerson(Genre genre)
        {
            _genreRepository.Remove(genre);
        }

        public void UpdateBookToPerson(Genre genre)
        {
            _genreRepository.Update(genre);
        }
    }
}
