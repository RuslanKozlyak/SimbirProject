using Data.DTO;
using Repository;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Author GetAuthor(int authorId)
        {
            return _authorRepository.Get(authorId);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }

        public IEnumerable<Author> GetAuthorByQuery(string query)
        {
            var findedAuthors = _authorRepository.GetAll()
              .Where(author => $"{author.FirstName}{author.LastName}{author.MiddleName}"
              .ToUpper().Contains(query.ToUpper()));
            return findedAuthors;
        }

        public void AddAuthor(Author author)
        {
            _authorRepository.Insert(author);
        }

        public void DeleteAuthor(Author author)
        {
            _authorRepository.Remove(author);
        }

        public void UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
        }
    }
}
