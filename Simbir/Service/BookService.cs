using AutoMapper;
using Domain.Data;
using Domain.DTO.BookDtos;
using Domain.DTO.GenreDtos;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    /// <inheritdoc cref="Domain.ServiceInterfaces.IBookService"/>
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return _mapper.ProjectTo<BookWithAuthorAndGenreDto>(books);
        }

        public BookWithAuthorAndGenreDto GetBook(int bookId)
        {
            return _mapper.Map<BookWithAuthorAndGenreDto>(_bookRepository.GetBook(bookId));
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetAuthorBooks(int authorId)
        {
            var book = _bookRepository.GetAllBooks()
                .Where(b => b.AuthorId == authorId);

            return _mapper.ProjectTo<BookWithAuthorAndGenreDto>(book);
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetByAuthorQuery(string query)
        {
            query = query.ToUpper();
            var books = _bookRepository.GetAllBooks()
            .Where(book => book.Author.FirstName.ToUpper().Contains(query)
              | book.Author.LastName.ToUpper().Contains(query)
              | book.Author.MiddleName.ToUpper().Contains(query));

            return _mapper.ProjectTo<BookWithAuthorAndGenreDto>(books);
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetByGenreQuery(string genreName)
        {
            var books = _bookRepository.GetAllBooks()
            .Where(book => book.Genres.Any(genre => genre.GenreName == genreName));

            return _mapper.ProjectTo<BookWithAuthorAndGenreDto>(books);
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetBookByYear(int yearOfWriting, bool sortByAlphabet)
        {
            var books = _bookRepository.GetAllBooks()
                .Where(book => book.YearOfWriting == yearOfWriting);

            var bookDto = _mapper.ProjectTo<BookWithAuthorAndGenreDto>(books);

            if (sortByAlphabet)
                return bookDto.OrderBy(book => book.Title);
            else
                return bookDto.OrderBy(book => book.Title).Reverse();
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetSortedBy(Enum sortBy)
        {
            switch (sortBy.ToString().ToUpper())
            {
                case "AUTHOR":
                    {
                        var books = _bookRepository.GetAllBooks()
                            .OrderBy(book => book.Author.LastName);

                        return _mapper.ProjectTo<BookWithAuthorAndGenreDto>(books);
                    }
                case "TITLE":
                    {
                        var books = _bookRepository.GetAllBooks()
                            .OrderBy(book => book.Title);

                        return _mapper.ProjectTo<BookWithAuthorAndGenreDto>(books);
                    }
                case "GENRE":
                    {
                        var books = _bookRepository.GetAllBooks()
                            .OrderBy(book => book.Genres.FirstOrDefault().GenreName);

                        return _mapper.ProjectTo<BookWithAuthorAndGenreDto>(books);
                    }
            }

            var unsorted = _bookRepository.GetAllBooks();
            return _mapper.ProjectTo<BookWithAuthorAndGenreDto>(unsorted);
        }

        public BookWithAuthorAndGenreDto AddGenreToBook(GenreWithoutBooksDto genreDto, int bookId)
        {
            var book = _bookRepository.GetBook(bookId);
            var genre = _mapper.Map<Genre>(genreDto);

            if (book.Genres.Contains(genre) == false)
                book.Genres.Add(genre);
            else
                throw new Exception("Такой жанр уже есть у книги!");

            _bookRepository.Update(book);
            return _mapper.Map<BookWithAuthorAndGenreDto>(_bookRepository.GetBook(book.Id));
        }

        public BookWithAuthorAndGenreDto DeleteGenreFromeBook(GenreWithoutBooksDto genreDto, int bookId)
        {
            var book = _bookRepository.GetBook(bookId);
            var genre = _mapper.Map<Genre>(genreDto);

            if (book.Genres.Contains(genre) == true)
                book.Genres.Remove(genre);
            else
                throw new Exception("Такой жанра нет у книги!");

            _bookRepository.Update(book);
            return _mapper.Map<BookWithAuthorAndGenreDto>(_bookRepository.GetBook(book.Id));
        }

        public BookWithAuthorAndGenreDto AddBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.Insert(book);
            var insertedAuthor = _bookRepository.GetAllBooks()
                .FirstOrDefault(b => b.Id == book.Id);

            return _mapper.Map<BookWithAuthorAndGenreDto>(insertedAuthor);
        }

        public void DeleteBook(int bookId)
        {
            var book = _bookRepository.GetBook(bookId);

            if (book.Humans.Count == 0)
                _bookRepository.Remove(book);
            else
                throw new Exception("Вы не можете удалить книгу, которая находится у пользователя!");
        }

        public BookWithAuthorAndGenreDto UpdateBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.Update(book);

            var updatedBook = _bookRepository.GetBook(book.Id);
            return _mapper.Map<BookWithAuthorAndGenreDto>(updatedBook);
        }
    }
}
