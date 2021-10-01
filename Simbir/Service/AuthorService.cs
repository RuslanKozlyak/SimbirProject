using AutoMapper;
using Domain.Data;
using Domain.DTO.AuthorDtos;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public AuthorWithoutBooksDto GetAuthor(int authorId)
        {
            var author = _mapper.Map<AuthorWithoutBooksDto>(_authorRepository.Get(authorId));
            return author;
        }

        public IEnumerable<AuthorWithoutBooksDto> GetAllAuthors()
        {
            var author = _authorRepository.GetAll();
            return author.Select(_mapper.Map<AuthorWithoutBooksDto>);
        }

        public IEnumerable<AuthorWithoutBooksDto> GetAuthorByQuery(string query)
        {
            var findedAuthors = _authorRepository.GetAll()
              .Where(author => $"{author.FirstName}{author.LastName}{author.MiddleName}"
              .ToUpper().Contains(query.ToUpper()));
            return findedAuthors.Select(_mapper.Map<AuthorWithoutBooksDto>);
        }

        public AuthorWithBooksDto AddAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _authorRepository.Insert(author);
            var insertedAuthor = _authorRepository.GetAll(include => include.Books)
                .FirstOrDefault(a => a.FirstName == author.FirstName);
            return _mapper.Map<AuthorWithBooksDto>(insertedAuthor);
        }

        public void DeleteAuthor(int authorId)
        {
            var author = _authorRepository.Get(authorId);
            if (author.Books.Count == 0)
                _authorRepository.Remove(author);
        }

        public AuthorWithBooksDto UpdateAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _authorRepository.Update(author);
            var updatedAuthor = _authorRepository.Get(author.Id, include => include.Books);
            return _mapper.Map<AuthorWithBooksDto>(updatedAuthor);
        }
    }
}
