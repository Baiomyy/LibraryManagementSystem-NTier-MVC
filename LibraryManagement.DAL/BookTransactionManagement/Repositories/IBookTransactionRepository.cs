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
    Task<List<BookTransaction>> GetAllWithBooksAsync();

    Task<BookTransaction?> GetLatestTransactionForBookAsync(int bookId);

    Task<BookTransaction?> GetByIdAsync(int id);

    Task AddAsync(BookTransaction transaction);

    Task ReturnBookAsync(BookTransaction transaction);
}