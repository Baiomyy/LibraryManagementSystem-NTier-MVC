using LibraryManagement.BLL.BookManagement.Dtos;

namespace LibraryManagement.BLL.BookManagement.Services;

public interface IBookService
{
    Task<List<BookDto>> GetAllBooksAsync();
    Task<BookDto?> GetBookByIdAsync(int id);
    Task AddBookAsync(BookDto model);
    Task UpdateBookAsync(BookDto model);
    Task DeleteBookAsync(int id);
    Task<(List<BookDto> Books, int TotalCount)> GetBooksPagedAsync(int pageNumber, int pageSize);
}
