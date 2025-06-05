//using LibraryManagement.DAL.Persistence;
//using LibraryManagement.Models;
//using Microsoft.EntityFrameworkCore;

//namespace LibraryManagement.DAL.BookTransactionManagement.Repositories;

//public class BookTransactionRepository : IBookTransactionRepository
//{
//    private readonly LibraryDbContext _context;

//    public BookTransactionRepository(LibraryDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<List<BookTransaction>> GetAllWithBooksAsync()
//    {
//        return await _context.BookTransactions.Include(t => t.Book).ToListAsync();
//    }

//    public async Task<BookTransaction?> GetLatestTransactionForBookAsync(int bookId)
//    {
//        return await _context.BookTransactions
//            .Where(t => t.BookId == bookId)
//            .OrderByDescending(t => t.BorrowedDate)
//            .FirstOrDefaultAsync();
//    }

//    public async Task<BookTransaction?> GetByIdAsync(int id)
//    {
//        return await _context.BookTransactions.Include(t => t.Book).FirstOrDefaultAsync(t => t.Id == id);
//    }

//    public async Task AddAsync(BookTransaction transaction)
//    {
//        _context.BookTransactions.Add(transaction);
//        await _context.SaveChangesAsync();
//    }

//    public async Task ReturnBookAsync(BookTransaction transaction)
//    {
//        transaction.ReturnedDate = DateTime.Now;
//        _context.BookTransactions.Update(transaction);
//        await _context.SaveChangesAsync();
//    }
//}
using LibraryManagement.DAL.Persistence;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DAL.BookTransactionManagement.Repositories;

public class BookTransactionRepository : IBookTransactionRepository
{
    private readonly LibraryDbContext _context;

    public BookTransactionRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<BookTransaction>> GetAllWithBooksAsync()
    {
        return await _context.BookTransactions
            .Include(t => t.Book)
            .ToListAsync();
    }

    public async Task<BookTransaction?> GetLatestTransactionForBookAsync(int bookId)
    {
        return await _context.BookTransactions
            .Where(t => t.BookId == bookId)
            .OrderByDescending(t => t.BorrowedDate)
            .Include(t => t.Book)
            .FirstOrDefaultAsync();
    }

    public async Task<BookTransaction?> GetByIdAsync(int id)
    {
        return await _context.BookTransactions
            .Include(t => t.Book)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(BookTransaction transaction)
    {
        _context.BookTransactions.Add(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task ReturnBookAsync(BookTransaction transaction)
    {
        transaction.ReturnedDate = DateTime.Now;
        _context.BookTransactions.Update(transaction);
        await _context.SaveChangesAsync();
    }
}
