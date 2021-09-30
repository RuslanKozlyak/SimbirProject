using Data.DTO;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IAuthorService
    {
        public Author GetAuthor(int authorId);
        public IEnumerable<Author> GetAllAuthors();
        public IEnumerable<Author> GetAuthorByQuery(string query);
        public void AddAuthor(Author author);
        public void DeleteAuthor(Author author);
        public void UpdateAuthor(Author author);
    }
}
