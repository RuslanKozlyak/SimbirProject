using Data.DTO;
using Repository;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class LibraryCardService : ILibraryCardService
    {
        private readonly IRepository<LibraryCard> _lcRepository;
        public LibraryCardService(IRepository<LibraryCard> lcRepository)
        {
            _lcRepository = lcRepository;
        }

        public IEnumerable<LibraryCard> GetAllCards()
        {
            return _lcRepository.GetAll();
        }

        public IEnumerable<LibraryCard> GetHumanBooks(int humanId)
        {
            return _lcRepository.GetAll().Where(lc => lc.HumanId == humanId);
        }

        public LibraryCard AddBookToPerson(Human human, Book book)
        {
            LibraryCard lc = new LibraryCard
            {
                HumanId = human.Id,
                BookId = book.Id,
                Date = DateTime.Now
            };
            _lcRepository.Insert(lc);
            return lc;
        }

        public void DeleteBookFromPerson(Human human, Book book)
        {
            var lc = _lcRepository.GetAll().Where(card => card.HumanId == human.Id & card.BookId == book.Id);
            _lcRepository.Remove(lc.ToList()[0]); ;
        }

        public void UpdateBookToPerson(LibraryCard card)
        {
            _lcRepository.Update(card);
        }
    }
}
