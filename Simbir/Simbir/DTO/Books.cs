using System;
using System.Collections.Generic;
using System.Linq;
namespace Simbir.DTO
{
    public class Books
    {
        /// <summary>
        /// Часть 2. п.2.3 Создание статичного списка книг
        /// </summary>
        private static List<BookDto> _listOfBooks = new List<BookDto>();
        public static List<BookDto> BookList
        {
            get
            {
                return _listOfBooks;
            }
            set
            {
                _listOfBooks = value;
            }
        }
        public static IEnumerable<BookDto> GetAll()
        {
            return Books.BookList;
        }

        public static IEnumerable<BookDto> GetSortedBy(string sortBy)
        {
            switch (sortBy)
            {
                case "Author":
                    return Books.BookList.OrderBy(book => book.Author);
                case "Title":
                    return Books.BookList.OrderBy(book => book.Author);
                case "Genre":
                    return Books.BookList.OrderBy(book => book.Genre);
            }
            return null;
        }

        public static bool AreAuthor(HumanDto human)
        {
            foreach (var book in BookList)
            {
                if (book.Author == human.Id)
                    return true;
            }
            return false;
        }

        public static IEnumerable<BookDto> AuthoredBy(HumanDto author)
        {
            return _listOfBooks.Where(book => book.Author == author.Id);
        }

        public static BookDto FindBook(BookDto book)
        {
            return BookList.FirstOrDefault(b => b.Id == book.Id);
        }

        public static string AddBook(BookDto book)
        {
            try
            {
                var findedBook = Books.FindBook(book);
                if(findedBook == null)
                {
                    Books.BookList.Add(findedBook);
                    return "Книга успешно добавлена!";
                }
                else
                {
                    return "Такая книга уже существует!";
                }
                    
            }
            catch (Exception ex)
            {
                return $"Книга не добавлена! Ошибка: [ {ex.Message} ]";
            }
        }

        public static string DeleteBook(BookDto book)
        {
            try
            {
                var findedBook = Books.FindBook(book);
                Books.BookList.Remove(findedBook);
                return "Книга успешно удалена!";
            }
            catch(Exception ex)
            {
                return $"Книга не удалена! Ошибка: [ {ex.Message} ]";
            }
        }
    }
}
