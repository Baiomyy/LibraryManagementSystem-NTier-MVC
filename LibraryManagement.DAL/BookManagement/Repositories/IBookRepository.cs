using LibraryManagement.Models;


namespace LibraryManagement.DAL.BookManagement.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(Book book);
    Task<int> GetTotalCountAsync();
    Task<List<Book>> GetPagedAsync(int pageNumber, int pageSize);
    //Task<PaginatedList<Book>> GetBooksPagedAsync(int pageNumber, int pageSize);

}
