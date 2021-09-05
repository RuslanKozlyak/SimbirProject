using System.Collections.Generic;
using System.Linq;
namespace Simbir.DTO
{
    public class Books
    {
        /// <summary>
        /// Часть 2. п.2.3 Создание статичного списка книг
        /// </summary>
        static List<BookDto> listOfBooks = new List<BookDto>
        {
            new BookDto { 
                Title = "Евгений Онегин", 
                Author = new HumanDto { FullName = "Александр Сергеевич Пушкин", Birthday = "06.06.1799" }, 
                Genre = "Роман" },
            new BookDto { 
                Title = "Анна Каренина", 
                Author =  new HumanDto { FullName = "Лев Николаевич Толстой", Birthday = "28.08.1828" }, 
                Genre = "Драма" },
            new BookDto { 
                Title = "Обломов", 
                Author = new HumanDto { FullName = "Иван Иванович Иванов", Birthday = "01.01.2001" }, 
                Genre = "Сатира" }
        };
        public static List<BookDto> BooksList
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
            foreach (var book in BooksList)
            {
                if (book.Author.FullName == human.FullName)
                    return true;
            }
            return false;
        }

        public static IEnumerable<BookDto> AuthoredBy(HumanDto author)
        {
            return listOfBooks.Where(book => book.Author.FullName == author.FullName);
        }
        
        public static BookDto FindBook(BookDto book)
        {
            foreach (var element in BooksList)
            {
                if (book.Author == element.Author & book.Title == element.Title & book.Genre == element.Genre)
                    return element;
                break;
            }
            return null;
        }
    }
}
