using Microsoft.AspNetCore.Mvc;
using Simbir.DTO;

namespace Simbir.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LibraryCardsController : ControllerBase
    {
        [Route("[action]")]
        [HttpPost]
        public void PostAddLibraryCard([FromBody] LibraryCardDto libraryCard)
        {
            LibraryCards.LibraryCardsList.Add(libraryCard);
        }
    }
}
