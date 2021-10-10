using AutoMapper;
using Domain.Data;
using Domain.DTO.BookDtos;
using Domain.DTO.HumanDtos;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    /// <inheritdoc cref="Domain.ServiceInterfaces.IHumanService"/>
    public class HumanService : IHumanService
    {
        private readonly IHumanRepository _humanRepository;
        private readonly IMapper _mapper;
        public HumanService(IHumanRepository humanRepository, IMapper mapper)
        {
            _humanRepository = humanRepository;
            _mapper = mapper;
        }

        public IEnumerable<HumanWithoutBooksDto> GetAllHumans()
        {
            var humans = _humanRepository.GetAllHumans();
            return _mapper.ProjectTo<HumanWithoutBooksDto>(humans);
        }

        public HumanWithoutBooksDto GetHuman(int humanId)
        {
            return _mapper.Map<HumanWithoutBooksDto>(_humanRepository.GetHuman(humanId));
        }

        public IEnumerable<HumanWithoutBooksDto> GetHumanByQuery(string query)
        {
            query = query.ToUpper();
            var findedHumans = _humanRepository.GetAllHumans().ToList()
               .Where(human => human.FirstName.ToUpper().Equals(query)
              | human.LastName.ToUpper().Equals(query)
              | human.MiddleName.ToUpper().Equals(query));

            return _mapper.ProjectTo<HumanWithoutBooksDto>(findedHumans.AsQueryable());
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetHumanBooks(int humanId)
        {
            var books = (IQueryable)_humanRepository.GetHuman(humanId).Books;
            return _mapper.ProjectTo<BookWithAuthorAndGenreDto>(books);
        }

        public HumanWithBooksDto AddBookToHuman(HumanWithBooksDto humanDto, int humanId)
        {
            var human = _humanRepository.GetHuman(humanId);

            foreach (var bookDto in humanDto.Books)
            {
                var book = _mapper.Map<Book>(bookDto);
                if (human.Books.Contains(book) == false)
                    human.Books.Add(book);
            }

            _humanRepository.Update(human);
            return _mapper.Map<HumanWithBooksDto>(_humanRepository.GetHuman(human.Id));
        }

        public HumanWithBooksDto DeleteBookFromHuman(HumanWithBooksDto humanDto, int humanId)
        {
            var human = _humanRepository.GetHuman(humanId);

            foreach (var bookDto in humanDto.Books)
            {
                var book = _mapper.Map<Book>(bookDto);
                if (human.Books.Contains(book) == true)
                    human.Books.Remove(book);
            }

            _humanRepository.Update(human);
            return _mapper.Map<HumanWithBooksDto>(_humanRepository.GetHuman(human.Id));
        }

        public HumanWithoutBooksDto AddHuman(HumanDto humanDto)
        {
            var human = _mapper.Map<Human>(humanDto);
            _humanRepository.Insert(human);
            var insertedHuman = _humanRepository.GetAllHumans()
                .FirstOrDefault(b => b.Id == human.Id);

            return _mapper.Map<HumanWithoutBooksDto>(insertedHuman);
        }

        public void DeleteHuman(int humanId)
        {
            var book = _humanRepository.GetHuman(humanId);
            _humanRepository.Remove(book);
        }

        public HumanWithoutBooksDto UpdateHuman(HumanDto humanDto)
        {
            var human = _mapper.Map<Human>(humanDto);
            _humanRepository.Update(human);
            var updatedHuman = _humanRepository.GetHuman(human.Id);
            return _mapper.Map<HumanWithoutBooksDto>(updatedHuman);
        }

        public void DeleteHumanByName(HumanWithoutBooksDto humanDto)
        {
            var removedHumans = _humanRepository.GetAllHumans()
               .Where(findedHuman => findedHuman.FirstName.Equals(humanDto.FirstName, StringComparison.CurrentCultureIgnoreCase)
               & findedHuman.LastName.Equals(humanDto.LastName, StringComparison.CurrentCultureIgnoreCase)
               & findedHuman.MiddleName.Equals(humanDto.MiddleName, StringComparison.CurrentCultureIgnoreCase));

            foreach (var person in removedHumans)
                _humanRepository.Remove(person);
        }
    }
}
