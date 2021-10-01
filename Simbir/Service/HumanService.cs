using AutoMapper;
using Domain.Data;
using Domain.DTO.BookDtos;
using Domain.DTO.HumanDtos;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class HumanService : IHumanService
    {
        private readonly IRepository<Human> _humanRepository;
        private readonly IMapper _mapper;
        public HumanService(IRepository<Human> humanRepository, IMapper mapper)
        {
            _humanRepository = humanRepository;
            _mapper = mapper;
        }

        public IEnumerable<HumanWithoutBooksDto> GetAllHumans()
        {
            return _humanRepository.GetAll().Select(_mapper.Map<HumanWithoutBooksDto>);
        }

        public HumanWithoutBooksDto GetHuman(int humanId)
        {
            return _mapper.Map<HumanWithoutBooksDto>(_humanRepository.Get(humanId));
        }

        public IEnumerable<HumanWithoutBooksDto> GetHumanByQuery(string query)
        {
            var findedHuman = _humanRepository.GetAll()
               .Where(findedHuman => $"{findedHuman.FirstName}{findedHuman.LastName}{findedHuman.MiddleName}".ToUpper().Contains(query.ToUpper()));
            return findedHuman.Select(_mapper.Map<HumanWithoutBooksDto>);

        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetHumanBooks(int humanId)
        {
            var books = _humanRepository.Get(humanId, include => include.Books).Books;
            return books.Select(_mapper.Map<BookWithAuthorAndGenreDto>);
        }

        public HumanWithBooksDto AddBookToHuman(HumanWithBooksDto humanDto, int humanId)
        {
            var human = _humanRepository.Get(humanId);
            foreach (var bookDto in humanDto.Books)
            {
                var book = _mapper.Map<Book>(bookDto);
                if (human.Books.Contains(book) == false)
                    human.Books.Add(book);
            }
            _humanRepository.Update(human);
            return _mapper.Map<HumanWithBooksDto>(_humanRepository.Get(human.Id, include => include.Books));
        }

        public HumanWithBooksDto DelteBookFromHuman(HumanWithBooksDto humanDto, int humanId)
        {
            var human = _humanRepository.Get(humanId);
            foreach (var bookDto in humanDto.Books)
            {
                var book = _mapper.Map<Book>(bookDto);
                if (human.Books.Contains(book) == true)
                    human.Books.Remove(book);
            }
            _humanRepository.Update(human);
            return _mapper.Map<HumanWithBooksDto>(_humanRepository.Get(human.Id, include => include.Books));
        }

        public HumanWithoutBooksDto AddHuman(HumanDto humanDto)
        {
            var human = _mapper.Map<Human>(humanDto);
            _humanRepository.Insert(human);
            var insertedHuman = _humanRepository.GetAll().FirstOrDefault(b => b.Id == human.Id);
            return _mapper.Map<HumanWithoutBooksDto>(insertedHuman);
        }

        public void DeleteHuman(int humanId)
        {
            var book = _humanRepository.Get(humanId);
            _humanRepository.Remove(book);
        }

        public HumanWithoutBooksDto UpdateHuman(HumanDto humanDto)
        {
            var human = _mapper.Map<Human>(humanDto);
            _humanRepository.Update(human);
            var updatedHuman = _humanRepository.Get(human.Id);
            return _mapper.Map<HumanWithoutBooksDto>(updatedHuman);
        }

        public void DeleteHumanByName(string humanFullName)
        {
            var removedHumans = _humanRepository.GetAll()
               .Where(findedHuman => $"{findedHuman.FirstName}{findedHuman.LastName}{findedHuman.MiddleName}".ToUpper() == humanFullName.ToUpper());
            foreach (var person in removedHumans)
                _humanRepository.Remove(person);
        }
    }
}
