using AutoMapper;
using Domain.Data;
using Domain.DTO.GenreDtos;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    /// <inheritdoc cref="Domain.ServiceInterfaces.IGenreService"/>
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public GenreWithoutBooksDto GetGenre(int genreId)
        {
            return _mapper.Map<GenreWithoutBooksDto>(_genreRepository.GetGenre(genreId));
        }

        public IEnumerable<GenreWithoutBooksDto> GetAllGenres()
        {
            var genres = _genreRepository.GetAllGenres();
            return _mapper.ProjectTo<GenreWithoutBooksDto>(genres);
        }

        public IEnumerable<GenreStatisticsDto> GetGenreStatistics()
        {
            var genres = _genreRepository.GetAllGenres();
            return _mapper.ProjectTo<GenreStatisticsDto>(genres);
        }

        public GenreWithoutBooksDto AddGenre(GenreWithoutBooksDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            _genreRepository.Insert(genre);
            var insertedAuthor = _genreRepository.GetAllGenres()
                .FirstOrDefault(b => b.GenreName == genreDto.GenreName);

            return _mapper.Map<GenreWithoutBooksDto>(insertedAuthor);
        }

        public void DeleteGenre(int genreId)
        {
            var genre = _genreRepository.GetGenre(genreId);
            _genreRepository.Remove(genre);
        }

        public GenreWithoutBooksDto UpdateGenre(GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            _genreRepository.Update(genre);
            var updatedGenre = _genreRepository.GetAllGenres()
                .FirstOrDefault(b => b.Id == genre.Id);

            return _mapper.Map<GenreWithoutBooksDto>(updatedGenre);
        }
    }
}
