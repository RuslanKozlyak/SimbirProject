using Data.DTO;
using Repository;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class HumanService : IHumanService
    {
        private readonly IRepository<Human> _humanRepository;

        public HumanService(IRepository<Human> humanRepository)
        {
            _humanRepository = humanRepository;
        }

        public IEnumerable<Human> GetAllHumans()
        {
            return _humanRepository.GetAll();
        }

        public Human GetHuman(int humanId)
        {
            return _humanRepository.Get(humanId);
        }

        public IEnumerable<Human> GetHumanByQuery(string query)
        {
            var findedHuman = _humanRepository.GetAll()
               .Where(findedHuman => $"{findedHuman.FirstName}{findedHuman.LastName}{findedHuman.MiddleName}".ToUpper().Contains(query.ToUpper()));
            return findedHuman;

        }

        public IEnumerable<Human> GetSortedBy(string sortBy)
        {
            switch (sortBy.ToString().ToUpper())
            {
            }
            return null;
        }

        public Human AddHuman(Human human)
        {
            _humanRepository.Insert(human);
            return _humanRepository.Get(human.Id);
        }

        public Human DeleteHuman(Human human)
        {
            _humanRepository.Remove(human);
            return human;
        }

        public Human UpdateHuman(Human human)
        {
            _humanRepository.Update(human);
            return _humanRepository.Get(human.Id);
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
