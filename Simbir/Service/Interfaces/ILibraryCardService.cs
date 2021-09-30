using Data.DTO;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface ILibraryCardService
    {
        public IEnumerable<LibraryCard> GetAllCards();
        public IEnumerable<LibraryCard> GetHumanBooks(int humanId);
        public LibraryCard AddBookToPerson(Human human, Book book);
        public void DeleteBookFromPerson(Human human, Book book);
        public void UpdateBookToPerson(LibraryCard card);
    }
}
