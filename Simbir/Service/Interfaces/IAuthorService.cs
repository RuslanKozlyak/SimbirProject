using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
