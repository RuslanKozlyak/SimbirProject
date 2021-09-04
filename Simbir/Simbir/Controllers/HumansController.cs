﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simbir.DTO;

namespace Simbir.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HumansController : ControllerBase
    {
        [Route("[action]")]
        [HttpGet]
        public IEnumerable<HumanDto> GetAll()
        {
            return Humans.ListOfHumans;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<HumanDto> GetAuthors()
        {
            return Humans.ListOfHumans.Where(human => Books.AreAuthor(human));
        }

        [Route("[action]")]
        [HttpGet]
        public HumanDto GetQuery([FromQuery]string query)
        {
            return Humans.GetContainingQuery(query);
        }

        [Route("[action]")]
        [HttpPost]
        public void PostAddHuman([FromBody] HumanDto human)
        {
            if(Humans.FindHuman(human)==null)
                Humans.ListOfHumans.Add(human);
        }

        [Route("[action]")]
        [HttpDelete]
        public void DeleteHuman([FromBody] HumanDto human)
        {
            var findedHuman = Humans.FindHuman(human);
            Humans.ListOfHumans.Remove(findedHuman);
        }
    }
}
