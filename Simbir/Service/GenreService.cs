using Data.DTO;
using Repository;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service
{
    public class GenreService : IGenreService
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

        public void AddGenre(Genre genre)
        {
            _genreRepository.Insert(genre);
        }

        public void DeleteGenre(Genre genre)
        {
            _genreRepository.Remove(genre);
        }

        public void UpdateGenre(Genre genre)
        {
            _genreRepository.Update(genre);
        }
    }
}
