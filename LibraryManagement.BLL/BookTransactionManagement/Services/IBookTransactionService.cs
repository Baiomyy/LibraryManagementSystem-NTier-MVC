using LibraryManagement.BLL.BookTransactionManagement.Dtos;
using LibraryManagement.Models;

namespace LibraryManagement.BLL.BookTransactionManagement.Services;

public interface IBookTransactionService
{
    Task<List<BookTransactionDto>> GetAllAsync(string? status, DateTime? borrowDate, DateTime? returnDate, int pageNumber, int pageSize);

    Task<BookTransactionDto?> GetTransactionByBookIdAsync(int bookId);

    Task BorrowAsync(int bookId);

    Task ReturnAsync(int transactionId);

    Task<(List<BookTransactionDto> Transactions, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, string? status, DateTime? borrowDate, DateTime? returnDate);

}