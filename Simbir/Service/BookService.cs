using AutoMapper;
using Domain.Data;
using Domain.DTO.BookDtos;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetAllBooks()
        {
            return _bookRepository.GetAll(include => include.Author, include => include.Genres).Select(_mapper.Map<BookWithAuthorAndGenreDto>);
        }

        public BookWithAuthorAndGenreDto GetBook(int bookId)
        {
            return _mapper.Map<BookWithAuthorAndGenreDto>(_bookRepository.Get(bookId, include => include.Author, include => include.Genres));
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetAuthorBooks(int authorId)
        {
            var book = _bookRepository.GetAll(include => include.Author, include => include.Genres)
                .Where(b => b.AuthorId == authorId);
            return book.Select(_mapper.Map<BookWithAuthorAndGenreDto>);
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetByAuthorQuery(string query)
        {
            var books = _bookRepository.GetAll(include => include.Author, include => include.Genres).ToList()
            .Where(book => $"{book.Author.FirstName}{book.Author.MiddleName}{book.Author.LastName}".ToUpper()
            .Contains(query.ToUpper()));
            return books.Select(_mapper.Map<BookWithAuthorAndGenreDto>);
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetByGenreQuery(string genreName)
        {
            var books = _bookRepository.GetAll(include => include.Author, include => include.Genres).ToList()
            .Where(book => book.Genres.Any(genre => genre.GenreName == genreName));
            return books.Select(_mapper.Map<BookWithAuthorAndGenreDto>);
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetBookByYear(int yearOfWriting, bool alphabetSort)
        {
            var books = _bookRepository.GetAll(include => include.Author, include => include.Genres)
                .Where(book => book.YearOfWriting == yearOfWriting);
            var bookDto = books.Select(_mapper.Map<BookWithAuthorAndGenreDto>);
            if (alphabetSort)
                return bookDto;
            else
            {
                return bookDto.Reverse();
            }
        }

        public IEnumerable<BookWithAuthorAndGenreDto> GetSortedBy(string sortBy)
        {
            switch (sortBy.ToUpper())
            {
                case "AUTHOR":
                    {
                        var books = _bookRepository.GetAll(include => include.Author, include => include.Genres)
                            .OrderBy(book => book.Author);
                        return books.Select(_mapper.Map<BookWithAuthorAndGenreDto>);
                    }

                case "TITLE":
                    {
                        var books = _bookRepository.GetAll(include => include.Author, include => include.Genres)
                            .OrderBy(book => book.Title);
                        return books.Select(_mapper.Map<BookWithAuthorAndGenreDto>);
                    }
                case "GENRE":
                    {
                        var books = _bookRepository.GetAll(include => include.Author, include => include.Genres)
                            .OrderBy(book => book.Genres);
                        return books.Select(_mapper.Map<BookWithAuthorAndGenreDto>);
                    }
            }
            var unsorted = _bookRepository.GetAll(include => include.Author, include => include.Genres);
            return unsorted.Select(_mapper.Map<BookWithAuthorAndGenreDto>);
        }

        public BookWithAuthorAndGenreDto AddGenreToBook(BookWithGenreDto bookDto, int bookId)
        {
            var book = _bookRepository.Get(bookId, include => include.Author, include => include.Genres);
            foreach (var genreDto in bookDto.Genres)
            {
                var genre = _mapper.Map<Genre>(genreDto);
                if (book.Genres.Contains(genre) == false)
                    book.Genres.Add(genre);
            }
            _bookRepository.Update(book);
            return _mapper.Map<BookWithAuthorAndGenreDto>(_bookRepository.Get(book.Id, include => include.Author, include => include.Genres));
        }

        public BookWithAuthorAndGenreDto DeleteGenreFromeBook(BookWithGenreDto bookDto, int bookId)
        {
            var book = _bookRepository.Get(bookId, include => include.Author, include => include.Genres);
            foreach (var genreDto in bookDto.Genres)
            {
                var genre = _mapper.Map<Genre>(genreDto);
                if (book.Genres.Contains(genre) == true)
                    book.Genres.Remove(genre);
            }
            _bookRepository.Update(book);
            return _mapper.Map<BookWithAuthorAndGenreDto>(_bookRepository.Get(book.Id, include => include.Author, include => include.Genres));
        }

        public BookWithAuthorAndGenreDto AddBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.Insert(book);
            var insertedAuthor = _bookRepository.GetAll(include => include.Author, include => include.Genres)
                .FirstOrDefault(b => b.Id == book.Id);
            return _mapper.Map<BookWithAuthorAndGenreDto>(insertedAuthor);
        }

        public void DeleteBook(int bookId)
        {
            var book = _bookRepository.Get(bookId, include => include.Author, include => include.Genres);
            if (book.Humans.Count == 0)
                _bookRepository.Remove(book);
        }

        public BookWithAuthorAndGenreDto UpdateBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.Update(book);
            var updatedBook = _bookRepository.Get(book.Id, include => include.Author, include => include.Genres);
            return _mapper.Map<BookWithAuthorAndGenreDto>(updatedBook);
        }
    }
}
