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

    public async Task<List<BookTransaction>> GetAllWithBooksAsync(int pageNumber, int pageSize)
    {
        return await _context.BookTransactions
            .Include(t => t.Book)
            .OrderByDescending(t => t.BorrowedDate)  // Optional: order by date descending
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
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

    // BookTransactionRepository.cs
    public async Task<(List<BookTransaction> Transactions, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, string? status, DateTime? borrowDate, DateTime? returnDate)
    {
        var query = _context.BookTransactions.Include(t => t.Book).AsQueryable();

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = status == "borrowed"
                ? query.Where(x => !x.ReturnedDate.HasValue)
                : query.Where(x => x.ReturnedDate.HasValue);
        }

        if (borrowDate.HasValue)
            query = query.Where(x => x.BorrowedDate.Date == borrowDate.Value.Date);

        if (returnDate.HasValue)
            query = query.Where(x => x.ReturnedDate.HasValue && x.ReturnedDate.Value.Date == returnDate.Value.Date);

        var totalCount = await query.CountAsync();

        var transactions = await query
            .OrderByDescending(x => x.BorrowedDate)  // optional ordering
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (transactions, totalCount);
    }

}
