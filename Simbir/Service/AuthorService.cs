using AutoMapper;
using Domain.Data;
using Domain.DTO.AuthorDtos;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    /// <inheritdoc cref="Domain.ServiceInterfaces.IAuthorService"/>
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public AuthorWithoutBooksDto GetAuthor(int authorId)
        {
            var author = _mapper.Map<AuthorWithoutBooksDto>(_authorRepository.GetAuthor(authorId));
            return author;
        }

        public IEnumerable<AuthorWithoutBooksDto> GetAllAuthors()
        {
            var author = _authorRepository.GetAllAuthors();
            return _mapper.ProjectTo<AuthorWithoutBooksDto>(author);
        }

        public IEnumerable<AuthorWithoutBooksDto> GetAuthorByQuery(string query)
        {
            query = query.ToUpper();
            var findedAuthors = _authorRepository.GetAllAuthors()
              .Where(author => author.FirstName.ToUpper().Contains(query)
              | author.LastName.ToUpper().Contains(query)
              | author.MiddleName.ToUpper().Contains(query));

            return _mapper.ProjectTo<AuthorWithoutBooksDto>(findedAuthors);
        }

        public AuthorWithBooksDto AddAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _authorRepository.Insert(author);

            var insertedAuthor = _authorRepository.GetAllAuthors()
                .FirstOrDefault(a => a.FirstName == author.FirstName);

            return _mapper.Map<AuthorWithBooksDto>(insertedAuthor);
        }

        public void DeleteAuthor(int authorId)
        {
            var author = _authorRepository.GetAuthor(authorId);

            if (author.Books.Count == 0)
                _authorRepository.Remove(author);
            else
                throw new Exception("Вы не можете удалить автора не удалив его книги!");
        }

        public AuthorWithBooksDto UpdateAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _authorRepository.Update(author);

            var updatedAuthor = _authorRepository.GetAuthor(author.Id);
            return _mapper.Map<AuthorWithBooksDto>(updatedAuthor);
        }
    }
}
