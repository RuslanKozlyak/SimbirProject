using System.Collections.Generic;
using System.Linq;
namespace Simbir.DTO
{
    public class Books
    {
        static List<BookDto> listOfBooks = new List<BookDto>
        {
            new BookDto { Title = "Евгений Онегин", Author = "Александр Сергеевич Пушкин", Genre = "Роман" },
            new BookDto { Title = "Анна Каренина", Author = "Лев Николаевич Толстой", Genre = "Драма" },
            new BookDto { Title = "Обломов", Author = "Иван Александрович Гончаров", Genre = "Сатира" }
        };
        public static List<BookDto> ListOfBooks
        {
            get
            {
                return listOfBooks;
            }
            set
            {
                listOfBooks = value;
            }
        }

        public static bool AreAuthor(HumanDto human)
        {
            foreach (var book in ListOfBooks)
            {
                if (book.Author == human.FullName)
                    return true;
            }
            return false;
        }
        public static IEnumerable<BookDto> AuthoredBy(string author)
        {
            return listOfBooks.Where(book => book.Author == author);
        }
        public static void RemoveBook(BookDto book)
        {
            foreach (var element in ListOfBooks)
            {
                if (book.Author == element.Author & book.Title == element.Title & book.Genre == element.Genre)
                    ListOfBooks.Remove(element);
                break;
            }
        }
    }
}
