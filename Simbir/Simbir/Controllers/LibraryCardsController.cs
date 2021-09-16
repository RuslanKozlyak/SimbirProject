using Microsoft.AspNetCore.Mvc;
using Simbir.DTO;

namespace Simbir.Controllers
{
    /// <summary>
    /// Часть 2.1 п.2 Создание контроллера, отвечающего за библиотечную карточку
    /// </summary>
    /// <returns></returns>
    [Route("[controller]")]
    [ApiController]
    public class LibraryCardsController : ControllerBase
    {
        //[Route("[action]")]
        //[HttpPost]
        ////public void PostAddLibraryCard([FromBody] LibraryCardDto libraryCard)
        ////{
        ////    LibraryCards.LibraryCardsList.Add(libraryCard);
        ////}
    }
}
