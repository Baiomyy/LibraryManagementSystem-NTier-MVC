using LibraryManagement.BLL.BookManagement.Dtos;
using LibraryManagement.DAL.BookManagement.Repositories;
using LibraryManagement.DAL.AuthorManagement.Repositories;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.BLL.BookManagement.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;

    public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    public async Task<List<BookDto>> GetAllBooksAsync()
    {
        // Get all books including the Author navigation property
        var books = await _bookRepository.GetAllAsync();

        // Map to BookDto including AuthorFullName
        var bookDtos = books.Select(b => new BookDto
        {
            Id = b.Id,
            Title = b.Title,
            Genre = b.Genre,
            Description = b.Description,
            AuthorId = b.AuthorId,
            AuthorFullName = b.Author?.FullName ?? "Unknown"
        }).ToList();

        return bookDtos;
    }

    public async Task<BookDto?> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book == null)
            return null;

        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Genre = book.Genre,
            Description = book.Description,
            AuthorId = book.AuthorId,
            AuthorFullName = book.Author?.FullName ?? "Unknown"
        };
    }

    public async Task AddBookAsync(BookDto model)
    {
        var book = new Book
        {
            Title = model.Title,
            Genre = model.Genre,
            Description = model.Description,
            AuthorId = model.AuthorId
        };

        await _bookRepository.AddAsync(book);
    }

    public async Task UpdateBookAsync(BookDto model)
    {
        var book = await _bookRepository.GetByIdAsync(model.Id);

        if (book == null)
            throw new Exception("Book not found");

        book.Title = model.Title;
        book.Genre = model.Genre;
        book.Description = model.Description;
        book.AuthorId = model.AuthorId;

        await _bookRepository.UpdateAsync(book);
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book == null)
            throw new Exception("Book not found");

        await _bookRepository.DeleteAsync(book);
    }
}
