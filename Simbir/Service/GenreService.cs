using AutoMapper;
using Domain.Data;
using Domain.DTO.GenreDtos;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;
        public GenreService(IRepository<Genre> genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public GenreWithoutBooksDto GetGenre(int genreId)
        {
            return _mapper.Map<GenreWithoutBooksDto>(_genreRepository.Get(genreId));
        }

        public IEnumerable<GenreWithoutBooksDto> GetAllGenres()
        {
            return _genreRepository.GetAll().Select(_mapper.Map<GenreWithoutBooksDto>);
        }

        public IEnumerable<GenreStatisticsDto> GetGenreStatistics()
        {
            var genres = _genreRepository.GetAll(include => include.Books);
            return genres.Select(_mapper.Map<GenreStatisticsDto>);
        }

        public GenreWithoutBooksDto AddGenre(GenreWithoutBooksDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            _genreRepository.Insert(genre);
            var insertedAuthor = _genreRepository.GetAll().FirstOrDefault(b => b.GenreName == genreDto.GenreName);
            return _mapper.Map<GenreWithoutBooksDto>(insertedAuthor);
        }

        public void DeleteGenre(int genreId)
        {
            var genre = _genreRepository.Get(genreId);
            _genreRepository.Remove(genre);
        }

        public GenreWithoutBooksDto UpdateGenre(GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            _genreRepository.Update(genre);
            var updatedGenre = _genreRepository.GetAll().FirstOrDefault(b => b.Id == genre.Id);
            return _mapper.Map<GenreWithoutBooksDto>(updatedGenre);
        }
    }
}
