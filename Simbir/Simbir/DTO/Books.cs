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
                Author = 1, 
                Genre = "Роман" },
            new BookDto { 
                Title = "Анна Каренина", 
                Author =  2, 
                Genre = "Драма" },
            new BookDto { 
                Title = "Обломов", 
                Author = 3, 
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
        public static IEnumerable<BookDto> GetAll()
        {
            return Books.BooksList;
        }

        public static IEnumerable<BookDto> GetSortedByAuthor()
        {
            return Books.BooksList.OrderBy(book => book.Author);
        }

        public static IEnumerable<BookDto> GetSortedByGenre()
        {
            return Books.BooksList.OrderBy(book => book.Genre);
        }

        public static IEnumerable<BookDto> GetSortedByTitle()
        {
            return Books.BooksList.OrderBy(book => book.Genre);
        }

        

        public static bool AreAuthor(HumanDto human)
        {
            foreach (var book in BooksList)
            {
                if (book.Author == human.Id)
                    return true;
            }
            return false;
        }

        public static IEnumerable<BookDto> AuthoredBy(HumanDto author)
        {
            return listOfBooks.Where(book => book.Author == author.Id);
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
