using LibraryManagement.Models;

namespace LibraryManagement.DAL.BookTransactionManagement.Repositories;

//public interface IBookTransactionRepository
//{
//    Task<List<BookTransaction>> GetAllWithBooksAsync();
//    Task<BookTransaction?> GetLatestTransactionForBookAsync(int bookId);
//    Task<BookTransaction?> GetByIdAsync(int id);
//    Task AddAsync(BookTransaction transaction);
//    Task ReturnBookAsync(BookTransaction transaction);
//}

public interface IBookTransactionRepository
{
    Task<List<BookTransaction>> GetAllWithBooksAsync(int pageNumber, int pageSize);

    Task<BookTransaction?> GetLatestTransactionForBookAsync(int bookId);

    Task<BookTransaction?> GetByIdAsync(int id);

    Task AddAsync(BookTransaction transaction);

    Task ReturnBookAsync(BookTransaction transaction);
    
    Task<(List<BookTransaction> Transactions, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, string? status, DateTime? borrowDate, DateTime? returnDate);

}
