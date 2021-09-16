using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IHumanService
    {
        public IEnumerable<Human> GetAllHumans();
        public Human GetHuman(int humanId);
        public IEnumerable<Human> GetHumanByQuery(string query);
        public IEnumerable<Human> GetSortedBy(string sortBy);
        public Human AddHuman(Human human);
        public Human DeleteHuman(Human human);
        public Human UpdateHuman(Human human);
        public void DeleteHumanByName(string humanFullName);
    }
}
